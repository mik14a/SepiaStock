using System;

using SepiaStock.Unity.ObservableModels;
using SepiaStock.Unity.Presenters.Interfaces;
using SepiaStock.Views;

using UniRx;

namespace SepiaStock.Unity.Presenters
{
    /// <summary>
    /// 写真プレゼンタークラス
    /// </summary>
    public class PhotoPresenter : IDynamicPresenter, IDisposable
    {
        /// <summary>
        /// 写真プレゼンターのインスタンスを作成します。
        /// </summary>
        public static PhotoPresenter CreateInstance(PhotoModel model, IPhotoView view)
        {
            return new PhotoPresenter(model, view);
        }

        /// <summary>選択状態を設定します。</summary>
        public bool Selected { set => _view.Selected = value; }
        /// <summary>選択イベント</summary>
        public event Action<PhotoModel> OnSelect;
        /// <summary>選択解除イベント</summary>
        public event Action<PhotoModel> OnUnSelect;

        /// <summary>
        /// プレゼンターを初期化します。
        /// </summary>
        public void Initialize()
        {
            _view.Photo = _model.Texture.Value;
            _view.OnSelect += () => OnSelect?.Invoke(_model);
            _view.OnUnSelect += () => OnUnSelect?.Invoke(_model);
        }

        /// <summary>
        /// プレゼンターを破棄します。
        /// </summary>
        public void Destroy()
        {
            _view.Destroy();
        }

        /// <summary>
        /// モデルと比較します。
        /// </summary>
        public bool Compare(PhotoModel model)
        {
            return _model == model;
        }

        /// <summary>
        /// リソースを解放します。
        /// </summary>
        public void Dispose()
        {
            _disposables.Dispose();
        }

        /// <summary>
        /// 写真プレゼンターのコンストラクタ
        /// </summary>
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
