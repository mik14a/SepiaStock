using System;

using SepiaStock.Unity.ObservableModels;
using SepiaStock.Unity.Presenters.Interfaces;
using SepiaStock.Views;

using UniRx;

namespace SepiaStock.Unity.Presenters
{
    /// <summary>
    /// ConfigPresenterクラスは、設定のプレゼンターを制御します。
    /// </summary>
    public class ConfigPresenter : IScenePresenter, IDisposable
    {
        /// <summary>戻るイベント</summary>
        public event Action OnBack;
        /// <summary>次へイベント</summary>
        public event Action<string> OnNext;

        /// <summary>
        /// ConfigPresenterの新しいインスタンスを作成します。
        /// </summary>
        public static ConfigPresenter CreateInstance(ConfigModel model, IConfigView view)
        {
            return new ConfigPresenter(model, view);
        }

        /// <summary>
        /// プレゼンターを初期化します。
        /// </summary>
        public void Initialize()
        {
            _model.PhotoFolderPath.Subscribe(p => _view.PhotoFolderPath = p).AddTo(_disposables);
            _model.AlbumFolderPath.Subscribe(p => _view.AlbumFolderPath = p).AddTo(_disposables);
            _model.FinalFolderPath.Subscribe(p => _view.FinalFolderPath = p).AddTo(_disposables);
            _model.Locale.Subscribe(l => _view.Locale = l).AddTo(_disposables);
            _view.OnPhotoFolderPathChanged += p => _model.ChangePhotoFolderPath(p);
            _view.OnAlbumFolderPathChanged += p => _model.ChangeAlbumFolderPath(p);
            _view.OnFinalFolderPathChanged += p => _model.ChangeFinalFolderPath(p);
            _view.OnLocaleChanged += l => _model.ChangeLocale(l);
            _view.OnOk += Ok;
            _view.OnCancel += Cancel;
        }

        /// <summary>
        /// プレゼンターを破棄します。
        /// </summary>
        public void Dispose()
        {
            _disposables.Dispose();
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
        readonly CompositeDisposable _disposables = new();
    }
}
