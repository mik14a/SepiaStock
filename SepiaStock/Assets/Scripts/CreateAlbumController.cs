using UnityEngine;
using UnityEngine.UI;

public class CreateAlbumController : MonoBehaviour
{
    [SerializeField]
    Button _backButton;

    void Awake()
    {
        _backButton.onClick.AddListener(OnBack);
    }

    void Update()
    {
        _commandManager.Execute();
    }

    void OnBack()
    {
        _commandManager.Push(new BackCommand());
    }

    readonly CommandManager _commandManager = new();
}
