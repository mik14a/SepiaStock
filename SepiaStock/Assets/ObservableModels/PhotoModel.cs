using UniRx;

using UnityEngine;

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
        public IReadOnlyReactiveProperty<Texture2D> Texture => _texture;

        /// <summary>
        /// 新しいPhotoModelインスタンスを作成します。
        /// </summary>
        /// <param name="texture">テクスチャ</param>
        /// <returns>新しいPhotoModelインスタンス</returns>
        public static PhotoModel CreateInstance(Texture2D texture)
        {
            return new PhotoModel(texture);
        }

        /// <summary>
        /// PhotoModelの新しいインスタンスを作成します。
        /// </summary>
        /// <param name="texture">テクスチャ</param>
        public PhotoModel(Texture2D texture)
        {
            _texture.Value = texture;
        }
        readonly ReactiveProperty<Texture2D> _texture = new();
    }
}
