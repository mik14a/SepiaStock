using System;

using SepiaStock.Unity.ObservableModels;
using SepiaStock.Unity.Presenters.Interfaces;
using SepiaStock.Views;

using UniRx;

namespace SepiaStock.Unity.Presenters
{
    /// <summary>
    /// 右メニュープレゼンタークラスです。選択モードの制御を担当します。
    /// </summary>
    public class RightMenuPresenter : IPresenter, IDisposable
    {
        /// <summary>
        /// 右メニュープレゼンターのインスタンスを作成します。
        /// </summary>
        public static RightMenuPresenter CreateInstance(PhotoSelectScene model, IRightMenuView view)
        {
            return new RightMenuPresenter(model, view);
        }

        /// <summary>通常選択モードのイベント</summary>
        public event Action OnNormalSelect;
        /// <summary>自動選択モードのイベント</summary>
        public event Action OnAutoSelect;

        /// <summary>
        /// 初期化処理を行います。
        /// </summary>
        public void Initialize()
        {
            _view.OnNormalSelecting += () => OnNormalSelect?.Invoke();
            _view.OnAutoSelecting += () => OnAutoSelect?.Invoke();
        }

        /// <summary>
        /// リソースの解放を行います。
        /// </summary>
        public void Dispose()
        {
            _disposables.Dispose();
        }

        /// <summary>
        /// 選択モードを変更します。
        /// </summary>
        public void ChangeSelectionMode(SelectionMode mode)
        {
            _view.SelectionMode = mode;
        }

        /// <summary>
        /// 右メニュープレゼンターのコンストラクタです。
        /// </summary>
        public RightMenuPresenter(PhotoSelectScene model, IRightMenuView view)
        {
            _model = model;
            _view = view;
        }
        readonly PhotoSelectScene _model;
        readonly IRightMenuView _view;
        readonly CompositeDisposable _disposables = new();
    }
}
