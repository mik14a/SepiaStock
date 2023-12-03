using System;

using SepiaStock.Unity.ObservableModels;

namespace SepiaStock.Views
{
    /// <summary>写真選択ビューのインターフェース</summary>
    public interface IPhotoSelectView
    {
        /// <summary>写真のスケールを設定</summary>
        float PhotoScale { set; }

        /// <summary>写真が選択されたときのイベント</summary>
        event Action<PhotoModel> OnSelectPhoto;
        /// <summary>写真の選択が解除されたときのイベント</summary>
        event Action<PhotoModel> OnUnSelectPhoto;
        /// <summary>写真のスケールが変更されたときのイベント</summary>
        event Action<float> OnPhotoScaleChanged;

        /// <summary>写真を追加</summary>
        void AddPhoto(PhotoModel photo);
        /// <summary>写真を削除</summary>
        void RemovePhoto(PhotoModel photo);
        /// <summary>選択された写真を追加</summary>
        void AddSelectedPhoto(PhotoModel photo);
        /// <summary>選択された写真を削除</summary>
        void RemoveSelectedPhoto(PhotoModel photo);
    }
}
