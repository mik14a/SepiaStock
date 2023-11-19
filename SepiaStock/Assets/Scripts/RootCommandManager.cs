using UnityEngine;
using UnityEngine.UI;

public class RootCommandManager : MonoBehaviour
{
    [SerializeField]
    Button _photoSelect;
    [SerializeField]
    Button _createAlbum;
    [SerializeField]
    Button _config;

    void Awake()
    {
        _photoSelect?.onClick.AddListener(OnPhotoSelect);
        _createAlbum?.onClick.AddListener(OnCreateAlbum);
        _config?.onClick.AddListener(OnConfig);
    }

    void Update()
    {
        _commandManager.Execute();
    }

    void OnPhotoSelect()
    {
        _commandManager.Push(new PhotoSelectCommand());
    }

    void OnCreateAlbum()
    {
        _commandManager.Push(new CreateAlbumCommand());
    }

    void OnConfig()
    {
        _commandManager.Push(new ConfigCommand());
    }

    readonly CommandManager _commandManager = new();
}
