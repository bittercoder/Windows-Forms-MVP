using DevDefined.Winforms.Framework.Commands;

namespace DevDefined.Winforms.Framework.Menus
{
    public interface IMenuRegistry
    {
        RootMenuModel Root { get; }
        CollectionMenuModel FindOrCreateCollection(string path);
        IMenuModel FindModel(string path);
        void AddCommand(ICommand command, AbstractMenuAttribute attribute);
        void AddMenuModel(string path, IMenuModel model);
        void Register(IMenuModelObserver observer);
        void UnRegister(IMenuModelObserver observer);
    }
}