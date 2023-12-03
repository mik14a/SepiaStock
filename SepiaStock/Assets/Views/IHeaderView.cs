using System;

namespace SepiaStock.Views
{
    /// <summary>ヘッダービューのインターフェース</summary>
    public interface IHeaderView
    {
        /// <summary>戻るボタンが押されたときのイベント</summary>
        event Action OnBack;
    }
}
