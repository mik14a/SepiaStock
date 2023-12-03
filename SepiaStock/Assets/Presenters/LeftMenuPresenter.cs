using System;

using SepiaStock.Unity.ObservableModels;
using SepiaStock.Unity.Presenters.Interfaces;
using SepiaStock.Views;

using UniRx;

namespace SepiaStock.Unity.Presenters
{
    public class LeftMenuPresenter : IPresenter, IDisposable
    {
        public static LeftMenuPresenter CreateInstance(PhotoSelectScene model, ILeftMenuView view)
        {
            return new LeftMenuPresenter(model, view);
        }

        public void Initialize()
        {
            _view.OnDelete += () => _model.DeleteSelection();
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        public LeftMenuPresenter(PhotoSelectScene model, ILeftMenuView view)
        {
            _model = model;
            _view = view;
        }
        readonly PhotoSelectScene _model;
        readonly ILeftMenuView _view;
        readonly CompositeDisposable _disposables = new CompositeDisposable();
    }
}
