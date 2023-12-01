using System.IO;

using SepiaStock.Models;

using UniRx;

using UnityEngine;

namespace SepiaStock.Unity.ObservableModels
{
    public class ConfigModel
    {
        public static ConfigModel CreateInstance()
        {
            var configPath = Path.Combine(Application.persistentDataPath, "Config.json");
            var config = File.Exists(configPath)
                ? JsonUtility.FromJson<Config>(File.ReadAllText(configPath))
                : Config.Default;
            return new ConfigModel(config);
        }

        public IReadOnlyReactiveProperty<string> PhotoFolderPath => _photoFolderPath;
        public IReadOnlyReactiveProperty<string> AlbumFolderPath => _albumFolderPath;
        public IReadOnlyReactiveProperty<string> FinalFolderPath => _finalFolderPath;

        public void Save()
        {
            _config.PhotoFolderPath = _photoFolderPath.Value;
            _config.AlbumFolderPath = _albumFolderPath.Value;
            _config.FinalFolderPath = _finalFolderPath.Value;
            var configPath = Path.Combine(Application.persistentDataPath, "Config.json");
            var json = JsonUtility.ToJson(_config);
            File.WriteAllText(configPath, json);
        }

        ConfigModel(Config config)
        {
            _config = config;
            _photoFolderPath = new ReactiveProperty<string>(_config.PhotoFolderPath);
            _albumFolderPath = new ReactiveProperty<string>(_config.AlbumFolderPath);
            _finalFolderPath = new ReactiveProperty<string>(_config.FinalFolderPath);
        }
        readonly Config _config;
        readonly ReactiveProperty<string> _photoFolderPath;
        readonly ReactiveProperty<string> _albumFolderPath;
        readonly ReactiveProperty<string> _finalFolderPath;
    }
}
