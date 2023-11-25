using System.Threading.Tasks;

public class BackCommand : ICommand
{
    public Task<bool> Execute()
    {
        SceneDirector.PopScene();
        return Task.FromResult(true);
    }

    public Task<bool> Redo() => throw new System.NotImplementedException();
    public Task<bool> Undo() => throw new System.NotImplementedException();

}
