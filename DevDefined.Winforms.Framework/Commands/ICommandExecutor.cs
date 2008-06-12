namespace DevDefined.Winforms.Framework.Commands
{
    public interface ICommandExecutor
    {
        void ExecuteCommandWithCallback(ICommand command, ICommand callback);
        void ExecuteCommand(ICommand command);
    }
}