using System;

using SepiaStock.Unity.ObservableModels;
using SepiaStock.Unity.Presenters.Interfaces;
using SepiaStock.Views;

using UniRx;

namespace SepiaStock.Unity.Presenters
{
    public class ConfigPresenter : IScenePresenter
    {
        public event Action OnBack;
        public event Func<string> OnNext;

        public static ConfigPresenter CreateInstance(ConfigModel model, IConfigView view)
        {
            return new ConfigPresenter(model, view);
        }

        public void Initialize()
        {
            _model.PhotoFolderPath.Subscribe(p => _view.PhotoFolderPath = p);
            _model.AlbumFolderPath.Subscribe(p => _view.AlbumFolderPath = p);
            _model.FinalFolderPath.Subscribe(p => _view.FinalFolderPath = p);
            _view.OnOk += Ok;
            _view.OnCancel += Cancel;
        }

        void Ok()
        {
            _model.Save();
            OnBack?.Invoke();
        }

        void Cancel()
        {
            OnBack?.Invoke();
        }

        ConfigPresenter(ConfigModel model, IConfigView view)
        {
            _model = model;
            _view = view;
        }
        readonly ConfigModel _model;
        readonly IConfigView _view;
    }
}
