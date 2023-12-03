using System;
using System.IO;

using SepiaStock.Unity.ObservableModels;
using SepiaStock.Unity.Presenters.Interfaces;
using SepiaStock.Views;

using UniRx;

using UnityEngine;

namespace SepiaStock.Unity.Presenters
{
    public class PhotoPresenter : IDynamicPresenter, IDisposable
    {
        public static PhotoPresenter CreateInstance(PhotoModel model, IPhotoView view)
        {
            return new PhotoPresenter(model, view);
        }

        public GameObject GameObject { get; set; }

        public void Initialize()
        {
            if (File.Exists(_model.Path.Value)) {
                var data = File.ReadAllBytes(_model.Path.Value);
                var texture = new Texture2D(32, 32);
                texture.LoadImage(data);
                _view.Photo = texture;
            }
        }

        public void Destroy()
        {
            _view.Destroy();
        }

        public bool Compare(PhotoModel model)
        {
            return _model == model;
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        public PhotoPresenter(PhotoModel model, IPhotoView view)
        {
            _model = model;
            _view = view;
        }
        readonly PhotoModel _model;
        readonly IPhotoView _view;
        readonly CompositeDisposable _disposables = new();
    }
}
