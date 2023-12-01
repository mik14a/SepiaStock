using System.Threading.Tasks;

class PhotoSelectCommand : ICommand
{
    public Task<bool> Execute()
    {
        SceneDirector.PushScene("PhotoSelectScene");
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
