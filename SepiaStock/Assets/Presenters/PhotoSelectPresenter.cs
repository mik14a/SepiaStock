using System;

using SepiaStock.Unity.ObservableModels;
using SepiaStock.Unity.Presenters.Interfaces;
using SepiaStock.Views;

using UniRx;

namespace SepiaStock.Unity.Presenters
{
    public class PhotoSelectPresenter : IScenePresenter, IDisposable
    {
        public static PhotoSelectPresenter CreateInstance(PhotoSelectScene model, IPhotoSelectView view)
        {
            return new PhotoSelectPresenter(model, view);
        }

        public event Action OnBack;
        public event Func<string> OnNext;

        public void Initialize()
        {
            _model.Photos.ObserveAdd().Subscribe(e => _view.AddPhoto(e.Value)).AddTo(_disposables);
            _model.Photos.ObserveRemove().Subscribe(e => _view.RemovePhoto(e.Value)).AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        PhotoSelectPresenter(PhotoSelectScene model, IPhotoSelectView view)
        {
            _model = model;
            _view = view;
        }

        readonly PhotoSelectScene _model;
        readonly IPhotoSelectView _view;
        readonly CompositeDisposable _disposables = new();
    }
}
