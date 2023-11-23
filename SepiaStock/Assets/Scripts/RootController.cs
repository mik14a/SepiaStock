using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ルートコントローラークラス
/// </summary>
class RootController : MonoBehaviour
{
    [SerializeField]
    /// <summary>
    /// 写真選択ボタン
    /// </summary>
    Button _photoSelect;
    [SerializeField]
    /// <summary>
    /// アルバム作成ボタン
    /// </summary>
    Button _createAlbum;
    [SerializeField]
    /// <summary>
    /// 設定ボタン
    /// </summary>
    Button _config;

    /// <summary>
    /// Awakeメソッド
    /// </summary>
    void Awake()
    {
        _photoSelect?.onClick.AddListener(OnPhotoSelect);
        _createAlbum?.onClick.AddListener(OnCreateAlbum);
        _config?.onClick.AddListener(OnConfig);
    }

    /// <summary>
    /// Updateメソッド
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
