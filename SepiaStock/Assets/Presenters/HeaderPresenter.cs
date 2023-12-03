using System;

using SepiaStock.Unity.Presenters.Interfaces;
using SepiaStock.Views;

namespace SepiaStock.Unity.Presenters
{
    /// <summary>
    /// ヘッダープレゼンタークラス
    /// </summary>
    public class HeaderPresenter : IPresenter
    {
        /// <summary>
        /// ヘッダープレゼンターのインスタンスを作成します。
        /// </summary>
        public static HeaderPresenter CreateInstance(IHeaderView view)
        {
            return new HeaderPresenter(view);
        }

        /// <summary>戻るイベント</summary>
        public event Action OnBack;

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            _view.OnBack += () => OnBack?.Invoke();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        HeaderPresenter(IHeaderView view)
        {
            _view = view;
        }
        readonly IHeaderView _view;
    }
}
