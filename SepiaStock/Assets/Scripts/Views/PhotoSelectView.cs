using System;
using System.IO;

using SepiaStock.Views;

using UnityEngine;
using UnityEngine.UI;

public class PhotoSelectView : MonoBehaviour, IPhotoSelectView
{
    [SerializeField]
    GameObject _photoGrid;

    public event Action OnBack;

    public void AddPhoto(string path)
    {
        var newPhoto = new GameObject();
        newPhoto.AddComponent<Image>();
        Texture2D texture = null;
        if (File.Exists(path)) {
            var fileData = File.ReadAllBytes(path);
            texture = new Texture2D(32, 32);
            texture.LoadImage(fileData);
        }
        newPhoto.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        newPhoto.transform.SetParent(_photoGrid.transform, false);
    }
}
