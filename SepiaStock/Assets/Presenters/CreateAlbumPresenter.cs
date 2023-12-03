using System;

using SepiaStock.Unity.Presenters.Interfaces;

namespace SepiaStock.Unity.Presenters
{
    /// <summary>
    /// アルバムを作成するプレゼンタークラスです。
    /// </summary>
    public class CreateAlbumPresenter : IScenePresenter
    {
        /// <summary>戻るイベント</summary>
        public event Action OnBack;
        /// <summary>次へイベント</summary>
        public event Action<string> OnNext;

        /// <summary>
        /// プレゼンターを初期化します。
        /// </summary>
        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
