using System.Threading.Tasks;

internal class CreateAlbumCommand : ICommand
{
    public Task<bool> Execute()
    {
        return Task.FromResult(true);
    }
}
