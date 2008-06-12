using Castle.Core;

namespace DevDefined.Winforms.Framework.Commands
{
    public interface ICommand : IStartable
    {
        string Text { get; }
        string Name { get; }
        //Pictures Picture { get; }
        void Execute();
    }
}