using System;

using UnityEngine;

namespace SepiaStock.Views
{
    public interface IPhotoView : IDynamicView
    {
        public bool Selected { set; }
        public Texture2D Photo { set; }

        event Action OnSelect;
        event Action OnUnSelect;
    }
}
