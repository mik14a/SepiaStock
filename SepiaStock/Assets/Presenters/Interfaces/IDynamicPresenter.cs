namespace SepiaStock.Unity.Presenters.Interfaces
{
    /// <summary>IDynamicPresenterインターフェースは、動的なプレゼンターを定義します。</summary>
    public interface IDynamicPresenter : IPresenter
    {
        /// <summary>プレゼンターを破棄します。</summary>
        void Destroy();
    }
}
