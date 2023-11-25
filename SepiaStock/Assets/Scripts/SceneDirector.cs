using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine.SceneManagement;

static class SceneDirector
{
    static string RootScene = "RootScene";

    static public void PushScene(string sceneName)
    {
        SceneStack.Push(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    static public void PopScene()
    {
        if (0 < SceneStack.Count) {
            SceneStack.Pop();
            var prevScene = 0 < SceneStack.Count ? SceneStack.Peek() : RootScene;
            SceneManager.LoadScene(prevScene);
        }
    }

    static readonly Stack<string> SceneStack = new();
}
