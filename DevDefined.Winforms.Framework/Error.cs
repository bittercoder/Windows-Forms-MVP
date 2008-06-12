using System;
using WeifenLuo.WinFormsUI.Docking;

namespace DevDefined.Winforms.Framework
{
    public static class Error
    {
        public static Exception ViewForPresenterDoesNotInheritFromDockContent(Type presenterType)
        {
            return
                new Exception(string.Format("View for presenter \"{0}\" does not iherit from \"{1}\".", presenterType,
                                            typeof (DockContent)));
        }

        public static Exception CanNotDockPresenterInsideItself(Type presenterType)
        {
            return new Exception(string.Format("Can not dock presenter of type \"{0}\" inside itself.", presenterType));
        }

        public static Exception ContextMenuAttributeMustHaveTargetTypeAssigned(Type type)
        {
            return
                new Exception(
                    string.Format(
                        "ContextMenuAttribute must have a TargetType assigned, attribute applied to type \"{0}\" does not.",
                        type));
        }

        public static Exception NoImageSourceFoundToHandleUri(Uri uri)
        {
            return new Exception(string.Format("No Image Source found to handle Uri \"{0}\".", uri));
        }
    }
}