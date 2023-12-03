using System;

using SepiaStock.Unity.Presenters.Interfaces;
using SepiaStock.Views;

namespace SepiaStock.Unity.Presenters
{
    public class RootPresenter : IPresenter
    {
        /// <summary>写真選択イベント</summary>
        public event Action OnPhotoSelect;

        /// <summary>アルバム作成イベント</summary>
        public event Action OnCreateAlbum;

        /// <summary>設定イベント</summary>
        public event Action OnConfig;

        /// <summary>RootPresenterのインスタンスを作成します。</summary>
        public static RootPresenter CreateInstance(IRootView view)
        {
            return new RootPresenter(view);
        }

        /// <summary>初期化処理</summary>
        public void Initialize()
        {
            _view.OnPhotoSelect += PhotoSelect;
            _view.OnCreateAlbum += CreateAlbum;
            _view.OnConfig += Config;
        }

        /// <summary>写真選択処理</summary>
        void PhotoSelect()
        {
            OnPhotoSelect?.Invoke();
        }

        /// <summary>アルバム作成処理</summary>
        void CreateAlbum()
        {
            OnCreateAlbum?.Invoke();
        }

        /// <summary>設定処理</summary>
        void Config()
        {
            OnConfig?.Invoke();
        }

        /// <summary>RootPresenterのコンストラクタ</summary>
        public RootPresenter(IRootView view)
        {
            _view = view;
        }
        readonly IRootView _view;
    }
}
