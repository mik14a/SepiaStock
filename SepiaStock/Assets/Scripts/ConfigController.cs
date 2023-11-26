using System.IO;

using UnityEngine;
using UnityEngine.UI;

using UniRx;

/// <summary>
/// 設定コントローラークラス
/// </summary>
class ConfigController : MonoBehaviour
{
    /// <summary>写真フォルダパスの入力フィールド</summary>
    [SerializeField]
    InputField _photoFolderPath;
    /// <summary>アルバムフォルダパスの入力フィールド</summary>
    [SerializeField]
    InputField _albumFolderPath;
    /// <summary>最終フォルダパスの入力フィールド</summary>
    [SerializeField]
    InputField _finalFolderPath;
    /// <summary>OKボタン</summary>
    [SerializeField]
    Button _okButton;
    /// <summary>キャンセルボタン</summary>
    [SerializeField]
    Button _cancelButton;

    public ConfigController()
    {
    }

    void Awake()
    {
        var configPath = Path.Combine(Application.persistentDataPath, "Config.json");
        var config = File.Exists(configPath) ? File.ReadAllText(configPath) : null;
        _configViewModel = ConfigViewModel.FromJson(config);
        _configViewModel.PhotoFolderPath.Subscribe(path => _photoFolderPath.text = path);
        _configViewModel.AlbumFolderPath.Subscribe(path => _albumFolderPath.text = path);
        _configViewModel.FinalFolderPath.Subscribe(path => _finalFolderPath.text = path);
        _photoFolderPath.onEndEdit.AddListener(text => _configViewModel.PhotoFolderPath.Value = text);
        _albumFolderPath.onEndEdit.AddListener(text => _configViewModel.AlbumFolderPath.Value = text);
        _finalFolderPath.onEndEdit.AddListener(text => _configViewModel.FinalFolderPath.Value = text);
        _okButton.onClick.AddListener(OkClick);
        _cancelButton.onClick.AddListener(CancelClick);
    }

    void Update()
    {
        _commandManager.Execute();
    }

    void OkClick()
    {
        var configPath = Path.Combine(Application.persistentDataPath, "Config.json");
        var configJson = ConfigViewModel.ToJson(_configViewModel);
        File.WriteAllText(configPath, configJson);
        _commandManager.Push(new BackCommand());
    }

    void CancelClick()
    {
        _commandManager.Push(new BackCommand());
    }

    /// <summary>コマンドマネージャー</summary>
    readonly CommandManager _commandManager = new();

    ConfigViewModel _configViewModel;

}
