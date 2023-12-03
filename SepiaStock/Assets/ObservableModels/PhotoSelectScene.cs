using System;
using System.Collections;
using System.IO;
using System.Linq;

using SepiaStock.Models;

using UniRx;

using UnityEngine;

namespace SepiaStock.Unity.ObservableModels
{
    /// <summary>
    /// PhotoSelectSceneクラスは、写真の選択シーンを制御します。
    /// </summary>
    public class PhotoSelectScene
    {
        /// <summary>
        /// PhotoSelectSceneの新しいインスタンスを作成します。
        /// </summary>
        public static PhotoSelectScene CreateInstance()
        {
            return new PhotoSelectScene();
        }

        /// <summary>
        /// 写真のコレクションを取得します。
        /// </summary>
        public IReadOnlyReactiveCollection<PhotoModel> Photos => _photos;
        /// <summary>
        /// 選択された写真のコレクションを取得します。
        /// </summary>
        public IReadOnlyReactiveCollection<PhotoModel> SelectedPhotos => _selectedPhotos;

        /// <summary>
        /// 写真をロードします。
        /// </summary>
        public IEnumerator Load()
        {
            var files = Directory.EnumerateFiles(_config.PhotoFolderPath);
            foreach (var file in files) {
                if (Path.GetExtension(file) is ".png" or ".jpg") {
                    var texture = new Texture2D(16, 16);
                    texture.LoadImage(File.ReadAllBytes(file));
                    _photos.Add(PhotoModel.CreateInstance(texture));
                    yield return null;
                }
            }
        }

        /// <summary>
        /// 写真を選択に追加します。
        /// </summary>
        public void SelectionAdd(PhotoModel photo)
        {
            _selectedPhotos.Add(photo);
        }

        /// <summary>
        /// 写真を選択から削除します。
        /// </summary>
        public void SelectionRemove(PhotoModel photo)
        {
            _selectedPhotos.Remove(photo);
        }

        /// <summary>
        /// 選択した写真を削除します。
        /// </summary>
        public void DeleteSelection()
        {
            _selectedPhotos.ToList().ForEach(photo => _photos.Remove(photo));
            _selectedPhotos.Clear();
        }

        /// <summary>
        /// PhotoSelectSceneの新しいインスタンスを初期化します。
        /// </summary>
        PhotoSelectScene()
        {
            var configPath = Path.Combine(Application.persistentDataPath, "Config.json");
            _config = File.Exists(configPath)
                ? JsonUtility.FromJson<Config>(File.ReadAllText(configPath))
                : Config.Default;
        }
        readonly Config _config;
        readonly ReactiveCollection<PhotoModel> _photos = new();
        readonly ReactiveCollection<PhotoModel> _selectedPhotos = new();
    }
}
