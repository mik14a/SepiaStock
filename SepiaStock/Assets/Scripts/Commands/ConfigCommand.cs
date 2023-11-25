using System.Threading.Tasks;

using UnityEngine.SceneManagement;

class ConfigCommand : ICommand
{
    public Task<bool> Execute()
    {
        SceneDirector.PushScene("ConfigScene");
        return Task.FromResult(true);
    }

    public Task<bool> Undo() => throw new System.NotImplementedException();
    public Task<bool> Redo() => throw new System.NotImplementedException();

}
