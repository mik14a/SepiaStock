
using System;

using SepiaStock.Views;

using UnityEngine;
using UnityEngine.UI;

/// <summary>ルートビュークラス</summary>
public class RootView : MonoBehaviour, IRootView
{
    /// <summary>写真選択ボタン</summary>
    [SerializeField] Button _photoSelect;
    /// <summary>アルバム作成ボタン</summary>
    [SerializeField] Button _createAlbum;
    /// <summary>設定ボタン</summary>
    [SerializeField] Button _config;

    /// <summary>写真選択イベント</summary>
    public event Action OnPhotoSelect;
    /// <summary>アルバム作成イベント</summary>
    public event Action OnCreateAlbum;
    /// <summary>設定イベント</summary>
    public event Action OnConfig;

    /// <summary>Awakeメソッド</summary>
    void Awake()
    {
        _photoSelect.onClick.AddListener(() => OnPhotoSelect?.Invoke());
        _createAlbum.onClick.AddListener(() => OnCreateAlbum?.Invoke());
        _config.onClick.AddListener(() => OnConfig?.Invoke());
    }
}
