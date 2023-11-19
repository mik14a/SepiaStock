using System.Collections.Generic;

class CommandManager
{
    public void Push(ICommand command)
    {
        _commands.Push(command);
        _redoStack.Clear();
    }

    public async void Execute()
    {
        while (0 < _commands.Count) {
            _currentCommand = _commands.Peek();
            await _currentCommand.Execute();
            _undoStack.Push(_currentCommand);
            _commands.Pop();
        }
    }

    public async void Undo()
    {
        if (_undoStack.Count > 0) {
            _currentCommand = _undoStack.Peek();
            await _currentCommand.Undo();
            _redoStack.Push(_currentCommand);
            _undoStack.Pop();
        }
    }

    public async void Redo()
    {
        if (_redoStack.Count > 0) {
            _currentCommand = _redoStack.Peek();
            await _currentCommand.Redo();
            _undoStack.Push(_currentCommand);
            _redoStack.Pop();
        }
    }

    ICommand _currentCommand = null;
    readonly Stack<ICommand> _commands = new();
    readonly Stack<ICommand> _undoStack = new();
    readonly Stack<ICommand> _redoStack = new();
}
