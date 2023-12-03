using SepiaStock.Unity.ObservableModels;

namespace SepiaStock.Views
{
    public interface IPhotoSelectView
    {
        void AddPhoto(PhotoModel photo);
        void RemovePhoto(PhotoModel photo);
    }
}
