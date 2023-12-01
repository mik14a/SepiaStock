using System;

namespace SepiaStock.Unity.Presenters.Interfaces
{
    public interface IScenePresenter
    {
        event Action OnBack;
        event Func<string> OnNext;
    }
}
