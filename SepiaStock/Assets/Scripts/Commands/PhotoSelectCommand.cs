using System.Threading.Tasks;

using UnityEngine.SceneManagement;

class PhotoSelectCommand : ICommand
{
    public Task<bool> Execute()
    {
        return Task.FromResult(true);
    }
}
