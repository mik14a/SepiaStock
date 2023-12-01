using System;

using SepiaStock.Views;

using UnityEngine;
using UnityEngine.UI;

public class ConfigView : MonoBehaviour, IConfigView
{
    /// <summary>写真フォルダパスの入力フィールド</summary>
    [SerializeField] InputField _photoFolderPath;
    /// <summary>アルバムフォルダパスの入力フィールド</summary>
    [SerializeField] InputField _albumFolderPath;
    /// <summary>最終フォルダパスの入力フィールド</summary>
    [SerializeField] InputField _finalFolderPath;
    /// <summary>OKボタン</summary>
    [SerializeField] Button _okButton;
    /// <summary>キャンセルボタン</summary>
    [SerializeField] Button _cancelButton;

    public string PhotoFolderPath { set => _photoFolderPath.text = value; }
    public string AlbumFolderPath { set => _albumFolderPath.text = value; }
    public string FinalFolderPath { set => _finalFolderPath.text = value; }

    public event Action OnOk;
    public event Action OnCancel;

    void Awake()
    {
        _okButton?.onClick.AddListener(() => OnOk?.Invoke());
        _cancelButton?.onClick.AddListener(() => OnCancel?.Invoke());
    }
}
