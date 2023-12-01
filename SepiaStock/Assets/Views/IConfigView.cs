using System;

namespace SepiaStock.Views
{
    public interface IConfigView
    {
        /// <summary>写真のフォルダパス</summary>
        public string PhotoFolderPath { set; }
        /// <summary>アルバムのフォルダパス</summary>
        public string AlbumFolderPath { set; }
        /// <summary>最終的なフォルダパス</summary>
        public string FinalFolderPath { set; }
        /// <summary>OKボタンが押されたときのイベント</summary>
        event Action OnOk;
        /// <summary>キャンセルボタンが押されたときのイベント</summary>
        event Action OnCancel;
    }
}
