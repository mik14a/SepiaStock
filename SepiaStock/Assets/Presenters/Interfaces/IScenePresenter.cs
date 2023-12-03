using System;

namespace SepiaStock.Unity.Presenters.Interfaces
{
    public interface IScenePresenter : IPresenter
    {
        event Action OnBack;
        event Action<string> OnNext;
    }
}
