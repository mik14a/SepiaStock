using System;

using SepiaStock.Unity.Presenters.Interfaces;
using SepiaStock.Views;

namespace SepiaStock.Unity.Presenters
{
    public class PhotoSelectPresenter : IScenePresenter
    {
        public static PhotoSelectPresenter CreateInstance(IPhotoSelectView view)
        {
            return new PhotoSelectPresenter(view);
        }

        public event Action OnBack;
        public event Func<string> OnNext;

        public void Initialize()
        {
        }

        PhotoSelectPresenter(IPhotoSelectView view)
        {
            _view = view;
        }
        private IPhotoSelectView _view;
    }
}
