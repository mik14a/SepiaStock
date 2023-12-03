using System;

using SepiaStock.Unity.ObservableModels;
using SepiaStock.Unity.Presenters.Interfaces;
using SepiaStock.Views;

using UniRx;

namespace SepiaStock.Unity.Presenters
{
    /// <summary>
    /// 写真選択プレゼンタークラス
    /// </summary>
    public class PhotoSelectPresenter : IScenePresenter, IDisposable
    {
        /// <summary>
        /// 写真選択プレゼンターのインスタンスを作成します。
        /// </summary>
        public static PhotoSelectPresenter CreateInstance(PhotoSelectScene model, IPhotoSelectView view)
        {
            return new PhotoSelectPresenter(model, view);
        }

        /// <summary>戻るイベント</summary>
        public event Action OnBack;
        /// <summary>次へイベント</summary>
        public event Action<string> OnNext;

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            _view.OnSelectPhoto += photo => _model.SelectionAdd(photo);
            _view.OnUnSelectPhoto += photo => _model.SelectionRemove(photo);
            _model.Photos.ObserveAdd().Subscribe(e => _view.AddPhoto(e.Value)).AddTo(_disposables);
            _model.Photos.ObserveRemove().Subscribe(e => _view.RemovePhoto(e.Value)).AddTo(_disposables);
            _model.SelectedPhotos.ObserveAdd().Subscribe(e => _view.AddSelectedPhoto(e.Value)).AddTo(_disposables);
            _model.SelectedPhotos.ObserveRemove().Subscribe(e => _view.RemoveSelectedPhoto(e.Value)).AddTo(_disposables);
        }

        /// <summary>
        /// リソースの解放
        /// </summary>
        public void Dispose()
        {
            _disposables.Dispose();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
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
