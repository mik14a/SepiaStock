using SepiaStock.Unity.Presenters;

using UnityEngine;

/// <summary>
/// ルートコントローラークラスです。アプリケーションのルート制御を担当します。
/// </summary>
class RootController : MonoBehaviour
{
    /// <summary>ルートビュー</summary>
    [SerializeField] RootView _view;

    /// <summary>初期化時に呼び出されます。</summary>
    void Awake()
    {
        _presenter = RootPresenter.CreateInstance(_view);
        _presenter.OnPhotoSelect += PhotoSelect;
        _presenter.OnCreateAlbum += CreateAlbum;
        _presenter.OnConfig += Config;
    }

    /// <summary>開始時に呼び出されます。</summary>
    void Start()
    {
        _presenter.Initialize();
    }

    /// <summary>更新時に呼び出されます。</summary>
    void Update()
    {
        _commandManager.Execute();
    }

    /// <summary>写真選択時に呼び出されます。</summary>
    void PhotoSelect()
    {
        _commandManager.Push(new PhotoSelectCommand());
    }

    /// <summary>アルバム作成時に呼び出されます。</summary>
    void CreateAlbum()
    {
        _commandManager.Push(new CreateAlbumCommand());
    }

    /// <summary>設定時に呼び出されます。</summary>
    void Config()
    {
        _commandManager.Push(new ConfigCommand());
    }

    /// <summary>
    /// コマンドマネージャー
    /// </summary>
    readonly CommandManager _commandManager = new();

    /// <summary>ルートプレゼンター</summary>
    RootPresenter _presenter;
}
