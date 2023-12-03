using UniRx;

namespace SepiaStock.Unity.ObservableModels
{
    /// <summary>
    /// PhotoModelクラスは、写真のモデルを制御します。
    /// </summary>
    public class PhotoModel
    {
        /// <summary>
        /// 写真のパスを取得します。
        /// </summary>
        public IReadOnlyReactiveProperty<string> Path => _path;

        /// <summary>
        /// 新しいPhotoModelインスタンスを作成します。
        /// </summary>
        /// <param name="path">写真のパス</param>
        /// <returns>新しいPhotoModelインスタンス</returns>
        public static PhotoModel CreateInstance(string path)
        {
            return new PhotoModel(path);
        }

        /// <summary>
        /// PhotoModelの新しいインスタンスを作成します。
        /// </summary>
        /// <param name="path">写真のパス</param>
        public PhotoModel(string path)
        {
            _path.Value = path;
        }
        readonly ReactiveProperty<string> _path = new();
    }
}
