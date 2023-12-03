using System;

using SepiaStock.Views;

using UnityEngine;
using UnityEngine.UI;

class PhotoView : MonoBehaviour, IPhotoView
{
    [SerializeField]
    Button _panel;

    [SerializeField]
    Color _normalColor;

    [SerializeField]
    Color _selectedColor;

    [SerializeField]
    Image _photo;

    public bool Selected {
        set {
            _selected = value;
            _panel.GetComponent<Image>().color = _selected ? _selectedColor : _normalColor;
        }
    }

    public Texture2D Photo {
        set => _photo.sprite = Sprite.Create(value, new Rect(0, 0, value.width, value.height), new Vector2(0.5f, 0.5f));
    }

    public event Action OnSelect;
    public event Action OnUnSelect;

    public void Destroy()
    {
        Destroy(gameObject);
    }

    void Awake()
    {
        _panel.GetComponent<Image>().color = _normalColor;
        _panel.onClick.AddListener(() => {
            var action = _selected ? OnUnSelect : OnSelect;
            action?.Invoke();
        });
    }

    bool _selected = false;
}
