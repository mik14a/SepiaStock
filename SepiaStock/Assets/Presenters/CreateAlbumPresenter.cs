using System;

using SepiaStock.Unity.Presenters.Interfaces;

namespace SepiaStock.Unity.Presenters
{
    public class CreateAlbumPresenter : IScenePresenter
    {
        public event Action OnBack;
        public event Action<string> OnNext;

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
