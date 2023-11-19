using System.Threading.Tasks;

interface ICommand
{
    public Task<bool> Execute();
}
