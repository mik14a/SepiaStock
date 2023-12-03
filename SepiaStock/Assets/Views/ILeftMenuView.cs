using System;

namespace SepiaStock.Views
{
    /// <summary>
    /// 左メニュービューのインターフェース
    /// </summary>
    public interface ILeftMenuView
    {
        /// <summary>選択イベント</summary>
        event Action OnSelect;
        /// <summary>削除イベント</summary>
        event Action OnDelete;
    }
}
