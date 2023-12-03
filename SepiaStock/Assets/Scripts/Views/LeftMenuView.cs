using System;

using SepiaStock.Views;

using UnityEngine;
using UnityEngine.UI;

/// <summary>左メニュービューのクラス</summary>
public class LeftMenuView : MonoBehaviour, ILeftMenuView
{
    /// <summary>選択ボタン</summary>
    [SerializeField] Button _selectButton;
    /// <summary>削除ボタン</summary>
    [SerializeField] Button _deleteButton;

    /// <summary>選択イベント</summary>
    public event Action OnSelect;
    /// <summary>削除イベント</summary>
    public event Action OnDelete;

    void Awake()
    {
        _selectButton.onClick.AddListener(() => OnSelect?.Invoke());
        _deleteButton.onClick.AddListener(() => OnDelete?.Invoke());
    }
}
