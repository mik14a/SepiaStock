using System;

namespace SepiaStock.Unity.Presenters.Interfaces
{
    /// <summary>
    /// IScenePresenterインターフェースは、シーンのプレゼンターを定義します。
    /// </summary>
    public interface IScenePresenter : IPresenter
    {
        /// <summary>バックイベント</summary>
        event Action OnBack;

        /// <summary>次のイベント</summary>
        /// <param name="next">次のシーン</param>
        event Action<string> OnNext;
    }
}
