using System;
using System.Collections;

using SepiaStock.Unity.ObservableModels;
using SepiaStock.Unity.Presenters;

using UnityEngine;
using UnityEngine.Networking;

public class PhotoSelectController : MonoBehaviour
{
    void Awake()
    {
        _scene = PhotoSelectScene.CreateInstance();
        _headerView = FindObjectOfType<HeaderView>();
        _headerPresenter = HeaderPresenter.CreateInstance(_headerView);
        _headerPresenter.OnBack += Back;
        _sceneView = FindObjectOfType<PhotoSelectView>();
        _scenePresenter = PhotoSelectPresenter.CreateInstance(_scene, _sceneView);
        _scenePresenter.OnNext += Next;
    }

    IEnumerator Start()
    {
        _headerPresenter.Initialize();
        _scenePresenter.Initialize();
        yield return _scene.Load();
    }

    void Update()
    {
        _commandManager.Execute();
    }

    void Back()
    {
        _commandManager.Push(new BackCommand());
    }

    string Next()
    {
        throw new NotImplementedException();
    }

    readonly CommandManager _commandManager = new();

    PhotoSelectScene _scene;
    HeaderView _headerView;
    PhotoSelectView _sceneView;

    HeaderPresenter _headerPresenter;
    PhotoSelectPresenter _scenePresenter;
}
