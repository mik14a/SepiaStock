using System;
using System.Collections;
using System.IO;

using SepiaStock.Models;

using UniRx;

using UnityEngine;

namespace SepiaStock.Unity.ObservableModels
{
    public class PhotoSelectScene
    {
        public static PhotoSelectScene CreateInstance()
        {
            return new PhotoSelectScene();
        }

        public IReadOnlyReactiveCollection<PhotoModel> Photos => _photos;
        public IReadOnlyReactiveCollection<PhotoModel> SelectedPhotos => _selectedPhotos;

        public IEnumerator Load()
        {
            var files = Directory.EnumerateFiles(_config.PhotoFolderPath);
            foreach (var file in files) {
                if (Path.GetExtension(file) is ".png" or ".jpg") {
                    _photos.Add(PhotoModel.CreateInstance(file));
                    yield return null;
                }
            }
        }

        public void SelectionAdd(PhotoModel photo)
        {
            _selectedPhotos.Add(photo);
        }

        public void SelectionRemove(PhotoModel photo)
        {
            _selectedPhotos.Remove(photo);
        }

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
