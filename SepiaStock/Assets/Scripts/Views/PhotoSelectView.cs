using System;
using System.Collections.Generic;
using System.Linq;

using SepiaStock.Unity.ObservableModels;
using SepiaStock.Unity.Presenters;
using SepiaStock.Views;

using UnityEngine;
using UnityEngine.UI;

/// <summary>写真選択ビューのクラス</summary>
public class PhotoSelectView : MonoBehaviour, IPhotoSelectView
{
    /// <summary>写真グリッド</summary>
    [SerializeField] GameObject _photoGrid;
    /// <summary>写真プレハブ</summary>
    [SerializeField] GameObject _photoPrefab;
    /// <summary>写真のスケール</summary>
    [SerializeField] Slider _photoScale;

    /// <summary>写真のスケールを設定する</summary>
    public float PhotoScale {
        set {
            _photoScale.value = value;
            _photoGrid.GetComponent<GridLayoutGroup>().cellSize = new Vector2(100 * value, 100 * value);
        }
    }

    /// <summary>写真選択イベント</summary>
    public event Action<PhotoModel> OnSelectPhoto;
    /// <summary>写真選択解除イベント</summary>
    public event Action<PhotoModel> OnUnSelectPhoto;
    /// <summary>戻るイベント</summary>
    public event Action OnBack;
    /// <summary>写真スケール変更イベント</summary>
    public event Action<float> OnPhotoScaleChanged;

    /// <summary>写真追加</summary>
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

    /// <summary>写真削除</summary>
    public void RemovePhoto(PhotoModel photo)
    {
        var photoToRemove = _photos.FirstOrDefault(p => p.Compare(photo));
        if (photoToRemove != null) {
            _photos.Remove(photoToRemove);
            photoToRemove.Destroy();
            photoToRemove.Dispose();
        }
    }

    /// <summary>選択写真追加</summary>
    public void AddSelectedPhoto(PhotoModel photo)
    {
        var photoSelected = _photos.FirstOrDefault(p => p.Compare(photo));
        if (photoSelected != null) {
            photoSelected.Selected = true;
        }
    }

    /// <summary>選択写真削除</summary>
    public void RemoveSelectedPhoto(PhotoModel photo)
    {
        var photoUnSelected = _photos.FirstOrDefault(p => p.Compare(photo));
        if (photoUnSelected != null) {
            photoUnSelected.Selected = false;
        }
    }

    void Awake()
    {
        _photoScale.onValueChanged.AddListener(scale => OnPhotoScaleChanged?.Invoke(scale));
    }

    /// <summary>写真プレゼンターリスト</summary>
    readonly List<PhotoPresenter> _photos = new();
}
