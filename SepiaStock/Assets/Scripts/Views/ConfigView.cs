using System;

using SepiaStock.Views;

using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

/// <summary>
/// 設定画面のビュークラス
/// </summary>
public class ConfigView : MonoBehaviour, IConfigView
{
    /// <summary>写真フォルダパスの入力フィールド</summary>
    [SerializeField] InputField _photoFolderPath;
    /// <summary>アルバムフォルダパスの入力フィールド</summary>
    [SerializeField] InputField _albumFolderPath;
    /// <summary>最終フォルダパスの入力フィールド</summary>
    [SerializeField] InputField _finalFolderPath;
    /// <summary>ロケール選択のドロップダウン</summary>
    [SerializeField] Dropdown _locale;
    /// <summary>OKボタン</summary>
    [SerializeField] Button _okButton;
    /// <summary>キャンセルボタン</summary>
    [SerializeField] Button _cancelButton;

    public string PhotoFolderPath { set => _photoFolderPath.text = value; }
    public string AlbumFolderPath { set => _albumFolderPath.text = value; }
    public string FinalFolderPath { set => _finalFolderPath.text = value; }
    public Locale Locale { set => _locale.value = _locale.options.FindIndex(option => option.text == value.LocaleName); }

    public event Action<string> OnPhotoFolderPathChanged;
    public event Action<string> OnAlbumFolderPathChanged;
    public event Action<string> OnFinalFolderPathChanged;
    public event Action<Locale> OnLocaleChanged;
    public event Action OnOk;
    public event Action OnCancel;

    /// <summary>
    /// Awake メソッド
    /// </summary>
    void Awake()
    {
        foreach (var locale in LocalizationSettings.AvailableLocales.Locales) {
            _locale.options.Add(new Dropdown.OptionData(locale.LocaleName));
        }
        _photoFolderPath.onValueChanged.AddListener(path => OnPhotoFolderPathChanged?.Invoke(path));
        _albumFolderPath.onValueChanged.AddListener(path => OnAlbumFolderPathChanged?.Invoke(path));
        _finalFolderPath.onValueChanged.AddListener(path => OnFinalFolderPathChanged?.Invoke(path));
        _locale.onValueChanged.AddListener(i => OnLocaleChanged?.Invoke(LocalizationSettings.AvailableLocales.Locales[i]));
        _okButton.onClick.AddListener(() => OnOk?.Invoke());
        _cancelButton.onClick.AddListener(() => OnCancel?.Invoke());
    }
}
