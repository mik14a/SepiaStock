
using System;

using SepiaStock.Views;

using UnityEngine;
using UnityEngine.UI;

public class RootView : MonoBehaviour, IRootView
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

    public event Action OnPhotoSelect;
    public event Action OnCreateAlbum;
    public event Action OnConfig;

    void Awake()
    {
        _photoSelect.onClick.AddListener(() => OnPhotoSelect?.Invoke());
        _createAlbum.onClick.AddListener(() => OnCreateAlbum?.Invoke());
        _config.onClick.AddListener(() => OnConfig?.Invoke());
    }
}
