using System;

using SepiaStock.Views;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 右メニュービュークラスです。選択モードの制御を担当します。
/// </summary>
public class RightMenuView : MonoBehaviour, IRightMenuView
{
    /// <summary>通常選択ボタン</summary>
    [SerializeField] Button _normalSelect;
    /// <summary>自動選択ボタン</summary>
    [SerializeField] Button _autoSelect;

    /// <summary>選択モードを設定します。</summary>
    public SelectionMode SelectionMode { set {
            _normalSelect.GetComponent<SelectableButton>().Selected = SelectionMode.Normal == value;
            _autoSelect.GetComponent<SelectableButton>().Selected = SelectionMode.Auto == value;
        }
    }

    /// <summary>通常選択イベント</summary>
    public event Action OnNormalSelecting;
    /// <summary>自動選択イベント</summary>
    public event Action OnAutoSelecting;

    /// <summary>初期化時に呼び出されます。</summary>
    void Awake()
    {
        _normalSelect.onClick.AddListener(() => OnNormalSelecting?.Invoke());
        _autoSelect.onClick.AddListener(() => OnAutoSelecting?.Invoke());
    }
}
