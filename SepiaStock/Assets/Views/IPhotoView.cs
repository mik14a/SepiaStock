using UnityEngine;

namespace SepiaStock.Views
{
    public interface IPhotoView : IDynamicView
    {
        public Texture2D Photo { set; }
    }
}
