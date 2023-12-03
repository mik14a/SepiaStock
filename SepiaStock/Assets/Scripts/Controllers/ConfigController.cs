using SepiaStock.Unity.ObservableModels;
using SepiaStock.Unity.Presenters;

using UnityEngine;

/// <summary>
/// 設定コントローラークラスです。設定画面の制御を担当します。
/// </summary>
class ConfigController : MonoBehaviour
{
    /// <summary>設定ビュー</summary>
    [SerializeField] ConfigView _view;

    /// <summary>初期化時に呼び出されます。</summary>
    void Awake()
    {
        _model = ConfigModel.CreateInstance();
        _presenter = ConfigPresenter.CreateInstance(_model, _view);
        _presenter.OnBack += Back;
    }

    /// <summary>開始時に呼び出されます。</summary>
    void Start()
    {
        _presenter.Initialize();
    }

    /// <summary>毎フレーム更新時に呼び出されます。</summary>
    void Update()
    {
        _commandManager.Execute();
    }

    /// <summary>戻るコマンドを実行します。</summary>
    void Back()
    {
        _commandManager.Push(new BackCommand());
    }

    /// <summary>コマンドマネージャー</summary>
    readonly CommandManager _commandManager = new();

    /// <summary>設定モデル</summary>
    ConfigModel _model;
    /// <summary>設定プレゼンター</summary>
    ConfigPresenter _presenter;
}
