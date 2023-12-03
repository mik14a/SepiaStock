using System;

using SepiaStock.Views;

using UnityEngine;
using UnityEngine.UI;

/// <summary>写真ビューのクラス</summary>
class PhotoView : MonoBehaviour, IPhotoView
{
    [SerializeField]
    /// <summary>パネル</summary>
    Button _panel;

    [SerializeField]
    /// <summary>通常色</summary>
    Color _normalColor;

    [SerializeField]
    /// <summary>選択色</summary>
    Color _selectedColor;

    [SerializeField]
    /// <summary>写真</summary>
    Image _photo;

    /// <summary>選択状態</summary>
    public bool Selected {
        set {
            _selected = value;
            _panel.GetComponent<Image>().color = _selected ? _selectedColor : _normalColor;
        }
    }

    /// <summary>写真</summary>
    public Texture2D Photo {
        set => _photo.sprite = Sprite.Create(value, new Rect(0, 0, value.width, value.height), new Vector2(0.5f, 0.5f));
    }

    /// <summary>選択イベント</summary>
    public event Action OnSelect;
    /// <summary>選択解除イベント</summary>
    public event Action OnUnSelect;

    /// <summary>破棄</summary>
    public void Destroy()
    {
        Destroy(gameObject);
    }

    /// <summary>初期化</summary>
    void Awake()
    {
        _panel.GetComponent<Image>().color = _normalColor;
        _panel.onClick.AddListener(() => {
            var action = _selected ? OnUnSelect : OnSelect;
            action?.Invoke();
        });
    }

    /// <summary>選択状態フラグ</summary>
    bool _selected = false;
}
