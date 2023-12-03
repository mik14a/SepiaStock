using System;

using SepiaStock.Views;

using UnityEngine;
using UnityEngine.UI;

/// <summary>ヘッダービュークラス</summary>
public class HeaderView : MonoBehaviour, IHeaderView
{
    /// <summary>戻るボタン</summary>
    [SerializeField] Button _backButton;

    /// <summary>戻るイベント</summary>
    public event Action OnBack;

    /// <summary>Awakeメソッド</summary>
    void Awake()
    {
        _backButton.onClick.AddListener(() => OnBack?.Invoke());
    }
}
