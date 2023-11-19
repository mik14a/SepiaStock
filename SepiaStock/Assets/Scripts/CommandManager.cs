using System.Collections.Generic;

class CommandManager
{
    public void Push(ICommand command)
    {
        _commands.Push(command);
    }

    public async void Execute()
    {
        if (_currentCommand is null) {
            _currentCommand = _commands.Peek();
            await _currentCommand.Execute();
        }
    }

    ICommand _currentCommand = null;
    readonly Stack<ICommand> _commands = new();
}
