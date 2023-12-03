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

    public event Action OnBack;

    public void AddPhoto(PhotoModel photo)
    {
        var instance = Instantiate(_photoPrefab, _photoGrid.transform, false);
        var view = instance.GetComponent<PhotoView>();
        var presenter = PhotoPresenter.CreateInstance(photo, view);
        presenter.Initialize();
        _photos.Add(presenter);
    }
        }
    }

    readonly List<PhotoPresenter> _photos = new();
}
