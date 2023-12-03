using System;
using System.Collections.Generic;
using System.Linq;

using SepiaStock.Unity.ObservableModels;
using SepiaStock.Unity.Presenters;
using SepiaStock.Views;

using UnityEngine;

public class PhotoSelectView : MonoBehaviour, IPhotoSelectView
{
    [SerializeField]
    GameObject _photoGrid;

    [SerializeField]
    GameObject _photoPrefab;

    public event Action<PhotoModel> OnSelectPhoto;
    public event Action<PhotoModel> OnUnSelectPhoto;
    public event Action OnBack;

    public void AddPhoto(PhotoModel photo)
    {
        var instance = Instantiate(_photoPrefab, _photoGrid.transform, false);
        var view = instance.GetComponent<PhotoView>();
        var presenter = PhotoPresenter.CreateInstance(photo, view);
        presenter.Initialize();
        presenter.OnSelect += (photo) => OnSelectPhoto?.Invoke(photo);
        presenter.OnUnSelect += (photo) => OnUnSelectPhoto?.Invoke(photo);
        _photos.Add(presenter);
    }

    public void RemovePhoto(PhotoModel photo)
    {
        var photoToRemove = _photos.FirstOrDefault(p => p.Compare(photo));
        if (photoToRemove != null) {
            _photos.Remove(photoToRemove);
            photoToRemove.Destroy();
            photoToRemove.Dispose();
        }
    }

    public void AddSelectedPhoto(PhotoModel photo)
    {
        var photoSelected = _photos.FirstOrDefault(p => p.Compare(photo));
        if (photoSelected != null) {
            photoSelected.Selected = true;
        }
    }

    public void RemoveSelectedPhoto(PhotoModel photo)
    {
        var photoUnSelected = _photos.FirstOrDefault(p => p.Compare(photo));
        if (photoUnSelected != null) {
            photoUnSelected.Selected = false;
        }
    }

    readonly List<PhotoPresenter> _photos = new();
}
