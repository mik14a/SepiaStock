using System;

using SepiaStock.Unity.Presenters.Interfaces;
using SepiaStock.Views;

namespace SepiaStock.Unity.Presenters
{
    public class HeaderPresenter : IPresenter
    {
        public static HeaderPresenter CreateInstance(IHeaderView view)
        {
            return new HeaderPresenter(view);
        }

        public event Action OnBack;

        public void Initialize()
        {
            _view.OnBack += () => OnBack?.Invoke();
        }

        HeaderPresenter(IHeaderView view)
        {
            _view = view;
        }
        readonly IHeaderView _view;
    }
}
