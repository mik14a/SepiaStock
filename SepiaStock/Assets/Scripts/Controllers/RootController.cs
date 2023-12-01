using SepiaStock.Unity.Presenters;
using SepiaStock.Views;

using UnityEngine;

/// <summary>
/// ルートコントローラークラス
/// </summary>
class RootController : MonoBehaviour
{
    void Awake()
    {
        _view = FindObjectOfType<RootView>();
        _presenter = RootPresenter.CreateInstance(_view);
        _presenter.OnPhotoSelect += PhotoSelect;
        _presenter.OnCreateAlbum += CreateAlbum;
        _presenter.OnConfig += Config;
    }

    void Start()
    {
        _presenter.Initialize();
    }

    void Update()
    {
        _commandManager.Execute();
    }

    void PhotoSelect()
    {
        _commandManager.Push(new PhotoSelectCommand());
    }

    void CreateAlbum()
    {
        _commandManager.Push(new CreateAlbumCommand());
    }

    void Config()
    {
        _commandManager.Push(new ConfigCommand());
    }

    /// <summary>
    /// コマンドマネージャー
    /// </summary>
    readonly CommandManager _commandManager = new();

    IRootView _view;
    RootPresenter _presenter;
}
