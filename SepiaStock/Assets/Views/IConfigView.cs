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
        /// <summary>OKされたときのイベント</summary>
        event Action OnOk;
        /// <summary>キャンセルされたときのイベント</summary>
        event Action OnCancel;
    }
}
