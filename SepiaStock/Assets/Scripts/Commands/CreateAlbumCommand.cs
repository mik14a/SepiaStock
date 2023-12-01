using System.Threading.Tasks;

class CreateAlbumCommand : ICommand
{
    public Task<bool> Execute()
    {
        SceneDirector.PushScene("CreateAlbumScene");
        return Task.FromResult(true);
    }

    public Task<bool> Undo()
    {
        throw new System.NotImplementedException();
    }

    public Task<bool> Redo()
    {
        throw new System.NotImplementedException();
    }
}
