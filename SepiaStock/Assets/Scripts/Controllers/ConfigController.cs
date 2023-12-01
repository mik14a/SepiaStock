using SepiaStock.Unity.ObservableModels;
using SepiaStock.Unity.Presenters;
using SepiaStock.Views;

using UnityEngine;

/// <summary>
/// 設定コントローラークラス
/// </summary>
class ConfigController : MonoBehaviour
{
    void Awake()
    {
        _model = ConfigModel.CreateInstance();
        _view = FindObjectOfType<ConfigView>();
        _presenter = ConfigPresenter.CreateInstance(_model, _view);
        _presenter.OnBack += Back;
    }

    void Start()
    {
        _presenter.Initialize();
    }

    void Update()
    {
        _commandManager.Execute();
    }

    void Back()
    {
        _commandManager.Push(new BackCommand());
    }

    /// <summary>コマンドマネージャー</summary>
    readonly CommandManager _commandManager = new();

    ConfigModel _model;
    IConfigView _view;
    ConfigPresenter _presenter;
}
