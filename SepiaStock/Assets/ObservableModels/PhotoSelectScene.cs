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

        public IReadOnlyReactiveCollection<string> Photos => _photos;

        public IEnumerator Load()
        {
            var files = Directory.EnumerateFiles(_config.PhotoFolderPath);
            foreach (var file in files) {
                if (Path.GetExtension(file) is ".png" or ".jpg") {
                    _photos.Add(file);
                    yield return null;
                }
            }
        }

        PhotoSelectScene()
        {
            var configPath = Path.Combine(Application.persistentDataPath, "Config.json");
            _config = File.Exists(configPath)
                ? JsonUtility.FromJson<Config>(File.ReadAllText(configPath))
                : Config.Default;
        }
        readonly Config _config;
        readonly ReactiveCollection<string> _photos = new();
    }
}
