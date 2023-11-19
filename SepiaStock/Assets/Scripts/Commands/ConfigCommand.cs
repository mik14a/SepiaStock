using System.Threading.Tasks;

class ConfigCommand : ICommand
{
    public Task<bool> Execute()
    {
        return Task.FromResult(true);
    }
}
