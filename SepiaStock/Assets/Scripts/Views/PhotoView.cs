using SepiaStock.Views;

using UnityEngine;
using UnityEngine.UI;

class PhotoView : MonoBehaviour, IPhotoView
{
    [SerializeField]
    Image _photo;

    public Texture2D Photo {
        set => _photo.sprite = Sprite.Create(value, new Rect(0, 0, value.width, value.height), new Vector2(0.5f, 0.5f));
    }
}
