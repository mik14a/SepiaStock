using System;

using UnityEngine;

namespace SepiaStock.Views
{
    /// <summary>写真ビューのインターフェース</summary>
    public interface IPhotoView : IDynamicView
    {
        /// <summary>選択状態</summary>
        public bool Selected { set; }
        /// <summary>写真</summary>
        public Texture2D Photo { set; }

        /// <summary>選択イベント</summary>
        event Action OnSelect;
        /// <summary>選択解除イベント</summary>
        event Action OnUnSelect;
    }
}
