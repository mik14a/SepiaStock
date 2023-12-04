using System;

using UnityEngine.Localization;

namespace SepiaStock.Views
{
    /// <summary>
    /// IConfigViewインターフェースは、設定ビューの動作を定義します。
    /// </summary>
    public interface IConfigView
    {
        /// <summary>写真のフォルダパスを設定します。</summary>
        public string PhotoFolderPath { set; }
        /// <summary>アルバムのフォルダパスを設定します。</summary>
        public string AlbumFolderPath { set; }
        /// <summary>最終的なフォルダパスを設定します。</summary>
        public string FinalFolderPath { set; }
        /// <summary>ロケールを設定します。</summary>
        public Locale Locale { set; }

        /// <summary>写真のフォルダパスが変更されたときに発生するイベント。</summary>
        event Action<string> OnPhotoFolderPathChanged;
        /// <summary>アルバムのフォルダパスが変更されたときに発生するイベント。</summary>
        event Action<string> OnAlbumFolderPathChanged;
        /// <summary>最終的なフォルダパスが変更されたときに発生するイベント。</summary>
        event Action<string> OnFinalFolderPathChanged;
        /// <summary>ロケールが変更されたときに発生するイベント。</summary>
        event Action<Locale> OnLocaleChanged;
        /// <summary>OKボタンが押されたときに発生するイベント。</summary>
        event Action OnOk;
        /// <summary>キャンセルボタンが押されたときに発生するイベント。</summary>
        event Action OnCancel;
    }
}
