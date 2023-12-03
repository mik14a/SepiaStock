using System;

using SepiaStock.Unity.ObservableModels;
using SepiaStock.Unity.Presenters.Interfaces;
using SepiaStock.Views;

using UniRx;

namespace SepiaStock.Unity.Presenters
{
    /// <summary>
    /// 写真選択プレゼンタークラスです。写真の選択とスケールの変更を制御します。
    /// </summary>
    public class PhotoSelectPresenter : IScenePresenter, IDisposable
    {
        /// <summary>
        /// 写真選択プレゼンターの新しいインスタンスを作成します。
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
        /// 初期化処理を行います。写真の追加、削除、選択、選択解除、スケール変更のイベントを設定します。
        /// </summary>
        public void Initialize()
        {
            _view.OnSelectPhoto += _model.SelectionAdd;
            _view.OnUnSelectPhoto += _model.SelectionRemove;
            _view.OnPhotoScaleChanged += ChangePhotoScale;
            _model.Photos.ObserveAdd().Subscribe(e => _view.AddPhoto(e.Value)).AddTo(_disposables);
            _model.Photos.ObserveRemove().Subscribe(e => _view.RemovePhoto(e.Value)).AddTo(_disposables);
            _model.SelectedPhotos.ObserveAdd().Subscribe(e => _view.AddSelectedPhoto(e.Value)).AddTo(_disposables);
            _model.SelectedPhotos.ObserveRemove().Subscribe(e => _view.RemoveSelectedPhoto(e.Value)).AddTo(_disposables);
        }

        /// <summary>
        /// 選択モードを変更します。
        /// </summary>
        public void ChangeSelectionMode(SelectionMode mode)
        {
            _selectionMode = mode;
        }

        /// <summary>
        /// 写真のスケールを変更します。
        /// </summary>
        public void ChangePhotoScale(float scale)
        {
            _photoScale = scale;
            _view.PhotoScale = _photoScale;
        }

        /// <summary>
        /// リソースの解放を行います。
        /// </summary>
        public void Dispose()
        {
            _disposables.Dispose();
        }

        /// <summary>
        /// コンストラクタです。モデルとビューを設定します。
        /// </summary>
        PhotoSelectPresenter(PhotoSelectScene model, IPhotoSelectView view)
        {
            _model = model;
            _view = view;
        }

        readonly PhotoSelectScene _model;
        readonly IPhotoSelectView _view;
        readonly CompositeDisposable _disposables = new();
        SelectionMode _selectionMode = SelectionMode.None;
        float _photoScale = 1f;
    }
}
