using System;

namespace SepiaStock.Views
{
    /// <summary>
    /// 右メニュービューのインターフェースを定義します。
    /// </summary>
    public interface IRightMenuView
    {
        /// <summary>選択モードを設定します。</summary>
        SelectionMode SelectionMode { set; }
        /// <summary>通常選択モードが選択されたときに発生するイベント。</summary>
        event Action OnNormalSelecting;
        /// <summary>自動選択モードが選択されたときに発生するイベント。</summary>
        event Action OnAutoSelecting;
    }
}
