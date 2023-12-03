using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 選択可能なボタンを表すクラスです。
/// </summary>
public class SelectableButton : MonoBehaviour
{
    /// <summary>選択状態を表すフィールドです。</summary>
    [SerializeField] bool _selected = false;
    /// <summary>通常色を表すフィールドです。</summary>
    [SerializeField] Color _normalColor = Color.white;
    /// <summary>選択色を表すフィールドです。</summary>
    [SerializeField] Color _selectedColor = Color.green;

    /// <summary>選択状態を取得または設定します。</summary>
    public bool Selected {
        get => _selected;
        set {
            if (_selected != value) {
                _selected = value;
                UpdateNormalColor();
            }
        }
    }

    /// <summary>初期化時に呼び出されます。</summary>
    void Awake()
    {
        _button = GetComponent<Button>();
        UpdateNormalColor();
    }

    /// <summary>通常色を更新します。</summary>
    void UpdateNormalColor()
    {
        var colors = _button.colors;
        colors.normalColor = _selected ? _selectedColor : _normalColor;
        _button.colors = colors;
    }

    /// <summary>ボタンコンポーネントを表すフィールドです。</summary>
    Button _button;
}
