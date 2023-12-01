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

        public static RootPresenter CreateInstance(IRootView view)
        {
            return new RootPresenter(view);
        }

        public void Initialize()
        {
            _view.OnPhotoSelect += PhotoSelect;
            _view.OnCreateAlbum += CreateAlbum;
            _view.OnConfig += Config;
        }

        void PhotoSelect()
        {
            OnPhotoSelect?.Invoke();
        }

        void CreateAlbum()
        {
            OnCreateAlbum?.Invoke();
        }

        void Config()
        {
            OnConfig?.Invoke();
        }

        public RootPresenter(IRootView view)
        {
            _view = view;
        }
        readonly IRootView _view;
    }
}
