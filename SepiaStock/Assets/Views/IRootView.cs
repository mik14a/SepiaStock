using System;

namespace SepiaStock.Views
{
    /// <summary>
    /// ルートビューのインターフェース
    /// </summary>
    public interface IRootView
    {
        /// <summary>写真選択イベント</summary>
        event Action OnPhotoSelect;

        /// <summary>アルバム作成イベント</summary>
        event Action OnCreateAlbum;

        /// <summary>設定イベント</summary>
        event Action OnConfig;
    }
}
