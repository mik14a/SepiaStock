using System;

using SepiaStock.Unity.ObservableModels;

namespace SepiaStock.Views
{
    public interface IPhotoSelectView
    {
        event Action<PhotoModel> OnSelectPhoto;
        event Action<PhotoModel> OnUnSelectPhoto;

        void AddPhoto(PhotoModel photo);
        void RemovePhoto(PhotoModel photo);
        void AddSelectedPhoto(PhotoModel photo);
        void RemoveSelectedPhoto(PhotoModel photo);
    }
}
