using System;
using System.IO;

using SepiaStock.Views;

using UnityEngine;

public class PhotoSelectView : MonoBehaviour, IPhotoSelectView
{
    [SerializeField]
    GameObject _photoGrid;

    [SerializeField]
    GameObject _photoPrefab;

    public event Action OnBack;

    public void AddPhoto(string path)
    {
        if (File.Exists(path)) {
            var data = File.ReadAllBytes(path);
            var texture = new Texture2D(32, 32);
            texture.LoadImage(data);
            var newPhoto = Instantiate(_photoPrefab, _photoGrid.transform, false);
            var view = newPhoto.GetComponent<PhotoView>();
            view.Photo = texture;
        }
    }
}
