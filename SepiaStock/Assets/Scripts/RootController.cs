using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ルートコントローラークラス
/// </summary>
class RootController : MonoBehaviour
{
    /// <summary>写真選択ボタン</summary>
    [SerializeField]
    Button _photoSelect;
    /// <summary>アルバム作成ボタン</summary>
    [SerializeField]
    Button _createAlbum;
    /// <summary>設定ボタン</summary>
    [SerializeField]
    Button _config;

    /// <summary>
    /// Awake メソッド
    /// </summary>
    void Awake()
    {
        _photoSelect?.onClick.AddListener(OnPhotoSelect);
        _createAlbum?.onClick.AddListener(OnCreateAlbum);
        _config?.onClick.AddListener(OnConfig);
    }

    /// <summary>
    /// Update メソッド
    /// </summary>
    void Update()
    {
        _commandManager.Execute();
    }

    /// <summary>
    /// 写真選択時の処理
    /// </summary>
    void OnPhotoSelect()
    {
        _commandManager.Push(new PhotoSelectCommand());
    }

    /// <summary>
    /// アルバム作成時の処理
    /// </summary>
    void OnCreateAlbum()
    {
        _commandManager.Push(new CreateAlbumCommand());
    }

    /// <summary>
    /// 設定時の処理
    /// </summary>
    void OnConfig()
    {
        _commandManager.Push(new ConfigCommand());
    }

    /// <summary>
    /// コマンドマネージャー
    /// </summary>
    readonly CommandManager _commandManager = new();
}
