using UniRx;

namespace SepiaStock.Unity.ObservableModels
{
    public class PhotoModel
    {
        public IReadOnlyReactiveProperty<string> Path => _path;

        public static PhotoModel CreateInstance(string path)
        {
            return new PhotoModel(path);
        }

        public PhotoModel(string path)
        {
            _path.Value = path;
        }
        readonly ReactiveProperty<string> _path = new();
    }
}
