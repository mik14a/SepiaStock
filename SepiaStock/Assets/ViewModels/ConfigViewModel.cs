using UniRx;

using UnityEngine;

public class ConfigViewModel
{
    public ReactiveProperty<string> PhotoFolderPath { get; }
    public ReactiveProperty<string> AlbumFolderPath { get; }
    public ReactiveProperty<string> FinalFolderPath { get; }

    ConfigViewModel(Config config)
    {
        _config = config;
        PhotoFolderPath = new ReactiveProperty<string>(_config.PhotoFolderPath);
        AlbumFolderPath = new ReactiveProperty<string>(_config.AlbumFolderPath);
        FinalFolderPath = new ReactiveProperty<string>(_config.FinalFolderPath);
    }

    // モデルの状態を更新するメソッド
    public void UpdateModel()
    {
        _config.PhotoFolderPath = PhotoFolderPath.Value;
        _config.AlbumFolderPath = AlbumFolderPath.Value;
        _config.FinalFolderPath = FinalFolderPath.Value;
    }

    public static ConfigViewModel FromJson(string json)
    {
        return new ConfigViewModel(json is not null ? JsonUtility.FromJson<Config>(json) : Config.Default);
    }

    public static string ToJson(ConfigViewModel configViewModel)
    {
        return JsonUtility.ToJson(configViewModel._config);
    }

    readonly Config _config;
}
