using System;
using System.Collections.Generic;
using System.Threading;

namespace DevDefined.Winforms.Framework.EventPublisher
{
    public class EventPublisher : IEventPublisher
    {
        private readonly SynchronizationContext _context;
        private readonly List<WeakReference> _listeners = new List<WeakReference>();

        public EventPublisher()
        {
            SynchronizationContext context = SynchronizationContext.Current;
            if (context == null)
            {
                context = new SynchronizationContext();
                SynchronizationContext.SetSynchronizationContext(context);
            }

            _context = SynchronizationContext.Current;
        }

        #region IEventPublisher Members

        public void PublishEvent<T>(T subject)
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                WeakReference reference = _listeners[i];
                if (reference.IsAlive)
                {
                    // Determine if a Listener handles the message of type T
                    // by trying to cast it
                    var receiver = reference.Target as IListener<T>;
                    if (receiver != null)
                    {
                        // I'm using SyncronizationContext to handle moving processing
                        // from a background thread to the UI thread without having 
                        // to worry about it in the View or Presenter
                        _context.Send(delegate { receiver.Handle(subject); }, null);
                    }
                }
                else
                {
                    _listeners.RemoveAt(i);
                }
            }
        }

        public void AddListener(IListener listener)
        {
            _listeners.Add(new WeakReference(listener));
        }

        public void RemoveListener(IListener listener)
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                WeakReference reference = _listeners[i];
                if ((!reference.IsAlive)
                    || (reference.Target == listener))
                {
                    _listeners.RemoveAt(i);
                }
            }
        }

        #endregion
    }
}