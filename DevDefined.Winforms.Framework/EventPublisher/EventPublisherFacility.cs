using Castle.Core;
using Castle.MicroKernel.Facilities;

namespace DevDefined.Winforms.Framework.EventPublisher
{
    public class EventPublisherFacility : AbstractFacility
    {
        private readonly IEventPublisher _eventPublisher = new EventPublisher();

        protected override void Init()
        {
            Kernel.AddComponentInstance("eventPublisher.default", typeof (IEventPublisher), _eventPublisher);
            Kernel.ComponentCreated += Kernel_ComponentCreated;
            Kernel.ComponentDestroyed += Kernel_ComponentDestroyed;
        }

        private void Kernel_ComponentDestroyed(ComponentModel model, object instance)
        {
            if (instance is IListener)
            {
                _eventPublisher.RemoveListener((IListener) instance);
            }
        }

        private void Kernel_ComponentCreated(ComponentModel model, object instance)
        {
            if (instance is IListener)
            {
                _eventPublisher.AddListener((IListener) instance);
            }
        }
    }
}