using System;
using System.Collections;

using SepiaStock.Unity.ObservableModels;
using SepiaStock.Unity.Presenters;
using SepiaStock.Views;

using UnityEngine;

/// <summary>
/// 写真選択コントローラー
/// </summary>
public class PhotoSelectController : MonoBehaviour
{
    /// <summary>写真選択ビュー</summary>
    [SerializeField] PhotoSelectView _sceneView;
    /// <summary>ヘッダービュー</summary>
    [SerializeField] HeaderView _headerView;
    /// <summary>左メニュービュー</summary>
    [SerializeField] LeftMenuView _leftMenuView;
    /// <summary>右メニュービュー</summary>
    [SerializeField] RightMenuView _rightMenuView;

    /// <summary>
    /// 初期化処理
    /// </summary>
    void Awake()
    {
        _scene = PhotoSelectScene.CreateInstance();
        _scenePresenter = PhotoSelectPresenter.CreateInstance(_scene, _sceneView);
        _scenePresenter.OnNext += Next;
        _headerPresenter = HeaderPresenter.CreateInstance(_headerView);
        _headerPresenter.OnBack += Back;
        _leftMenuPresenter = LeftMenuPresenter.CreateInstance(_scene, _leftMenuView);
        _rightMenuPresenter = RightMenuPresenter.CreateInstance(_scene, _rightMenuView);
        _rightMenuPresenter.OnNormalSelect += () => {
            _scenePresenter.ChangeSelectionMode(SelectionMode.Normal);
            _rightMenuPresenter.ChangeSelectionMode(SelectionMode.Normal);
        };
        _rightMenuPresenter.OnAutoSelect += () => {
            _scenePresenter.ChangeSelectionMode(SelectionMode.Auto);
            _rightMenuPresenter.ChangeSelectionMode(SelectionMode.Auto);
        };
    }

    /// <summary>
    /// 開始処理
    /// </summary>
    IEnumerator Start()
    {
        _headerPresenter.Initialize();
        _leftMenuPresenter.Initialize();
        _rightMenuPresenter.Initialize();
        _scenePresenter.Initialize();
        yield return _scene.Load();
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update()
    {
        _commandManager.Execute();
    }

    /// <summary>
    /// 破棄処理
    /// </summary>
    void OnDestroy()
    {
        _leftMenuPresenter.Dispose();
        _scenePresenter.Dispose();
    }

    /// <summary>
    /// 戻る処理
    /// </summary>
    void Back()
    {
        _commandManager.Push(new BackCommand());
    }

    /// <summary>
    /// 次へ処理
    /// </summary>
    void Next(string scene)
    {
        throw new NotImplementedException();
    }

    /// <summary>コマンドマネージャー</summary>
    readonly CommandManager _commandManager = new();

    /// <summary>写真選択シーン</summary>
    PhotoSelectScene _scene;
    /// <summary>写真選択プレゼンター</summary>
    PhotoSelectPresenter _scenePresenter;

    /// <summary>ヘッダープレゼンター</summary>
    HeaderPresenter _headerPresenter;
    /// <summary>左メニュープレゼンター</summary>
    LeftMenuPresenter _leftMenuPresenter;
    /// <summary>右メニュープレゼンター</summary>
    RightMenuPresenter _rightMenuPresenter;

}
