using System;

namespace SepiaStock.Models
{
    /// <summary>
    /// 設定クラス
    /// </summary>
    [Serializable]
    public class Config
    {
        public static readonly Config Default = new() {
            PhotoFolderPath = string.Empty,
            AlbumFolderPath = string.Empty,
            FinalFolderPath = string.Empty,
            Locale = string.Empty
        };

        /// <summary>写真のフォルダパス</summary>
        public string PhotoFolderPath;
        /// <summary>アルバムのフォルダパス</summary>
        public string AlbumFolderPath;
        /// <summary>最終的なフォルダパス</summary>
        public string FinalFolderPath;
        /// <summary>ロケール</summary>
        public string Locale;
    }
}
