using System.IO;
using System.Linq;

using SepiaStock.Models;

using UniRx;

using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace SepiaStock.Unity.ObservableModels
{
    /// <summary>
    /// ConfigModelクラスは、設定のモデルを制御します。
    /// </summary>
    public class ConfigModel
    {
        /// <summary>
        /// ConfigModelの新しいインスタンスを作成します。
        /// </summary>
        public static ConfigModel CreateInstance()
        {
            var configPath = Path.Combine(Application.persistentDataPath, "Config.json");
            var config = File.Exists(configPath)
                ? JsonUtility.FromJson<Config>(File.ReadAllText(configPath))
                : Config.Default;
            return new ConfigModel(config);
        }

        /// <summary>写真のフォルダパスを取得します。</summary>
        public IReadOnlyReactiveProperty<string> PhotoFolderPath => _photoFolderPath;
        /// <summary>アルバムのフォルダパスを取得します。</summary>
        public IReadOnlyReactiveProperty<string> AlbumFolderPath => _albumFolderPath;
        /// <summary>最終的なフォルダパスを取得します。</summary>
        public IReadOnlyReactiveProperty<string> FinalFolderPath => _finalFolderPath;
        /// <summary>ロケールを取得します。</summary>
        public IReadOnlyReactiveProperty<Locale> Locale => _locale;

        /// <summary>
        /// 設定を保存します。
        /// </summary>
        public void Save()
        {
            _config.PhotoFolderPath = _photoFolderPath.Value;
            _config.AlbumFolderPath = _albumFolderPath.Value;
            _config.FinalFolderPath = _finalFolderPath.Value;
            _config.Locale = _locale.Value.LocaleName;
            LocalizationSettings.SelectedLocale = _locale.Value;
            var configPath = Path.Combine(Application.persistentDataPath, "Config.json");
            var json = JsonUtility.ToJson(_config);
            File.WriteAllText(configPath, json);
        }

        /// <summary>
        /// 写真のフォルダパスを変更します。
        /// </summary>
        public void ChangePhotoFolderPath(string path)
        {
            _photoFolderPath.Value = path;
        }

        /// <summary>
        /// アルバムのフォルダパスを変更します。
        /// </summary>
        public void ChangeAlbumFolderPath(string path)
        {
            _albumFolderPath.Value = path;
        }

        /// <summary>
        /// 最終的なフォルダパスを変更します。
        /// </summary>
        public void ChangeFinalFolderPath(string path)
        {
            _finalFolderPath.Value = path;
        }

        /// <summary>
        /// ロケールを変更します。
        /// </summary>
        public void ChangeLocale(Locale locale)
        {
            _locale.Value = locale;
        }

        /// <summary>
        /// ConfigModelの新しいインスタンスを作成します。
        /// </summary>
        ConfigModel(Config config)
        {
            _config = config;
            _photoFolderPath.Value = _config.PhotoFolderPath;
            _albumFolderPath.Value = _config.AlbumFolderPath;
            _finalFolderPath.Value = _config.FinalFolderPath;
            _locale.Value = string.IsNullOrEmpty(_config.Locale)
                ? LocalizationSettings.SelectedLocale
                : LocalizationSettings.AvailableLocales.Locales.FirstOrDefault(locale => locale.LocaleName == _config.Locale)
                  ?? LocalizationSettings.SelectedLocale;
        }
        readonly Config _config;
        readonly ReactiveProperty<string> _photoFolderPath = new();
        readonly ReactiveProperty<string> _albumFolderPath = new();
        readonly ReactiveProperty<string> _finalFolderPath = new();
        readonly ReactiveProperty<Locale> _locale = new();
    }
}
