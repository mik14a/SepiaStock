using System.Collections.Generic;

using UnityEngine.SceneManagement;

static class SceneDirector
{
    static readonly string RootScene = "RootScene";

    public static void PushScene(string sceneName)
    {
        SceneStack.Push(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public static void PopScene()
    {
        if (0 < SceneStack.Count) {
            SceneStack.Pop();
            var prevScene = 0 < SceneStack.Count ? SceneStack.Peek() : RootScene;
            SceneManager.LoadScene(prevScene);
        }
    }

    static readonly Stack<string> SceneStack = new();
}
