using System.Collections.Generic;

/// <summary>
/// コマンド管理クラス
/// </summary>
class CommandManager
{
    /// <summary>
    /// Undoが可能かどうかを取得します
    /// </summary>
    public bool CanUndo => 0 < _undoStack.Count;
    /// <summary>
    /// Redoが可能かどうかを取得します
    /// </summary>
    public bool CanRedo => 0 < _redoStack.Count;

    /// <summary>
    /// コマンドをプッシュします
    /// </summary>
    public void Push(ICommand command)
    {
        _commands.Push(command);
        _redoStack.Clear();
    }

    /// <summary>
    /// コマンドを実行します
    /// </summary>
    public async void Execute()
    {
        while (0 < _commands.Count) {
            _currentCommand = _commands.Peek();
            await _currentCommand.Execute();
            _undoStack.Push(_currentCommand);
            _commands.Pop();
        }
    }

    /// <summary>
    /// Undoを実行します
    /// </summary>
    public async void Undo()
    {
        if (_undoStack.Count > 0) {
            _currentCommand = _undoStack.Peek();
            await _currentCommand.Undo();
            _redoStack.Push(_currentCommand);
            _undoStack.Pop();
        }
    }

    /// <summary>
    /// Redoを実行します
    /// </summary>
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
