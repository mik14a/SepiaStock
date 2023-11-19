using System.Threading.Tasks;

interface ICommand
{
    public Task<bool> Execute();
    public Task<bool> Undo();
    public Task<bool> Redo();
}
