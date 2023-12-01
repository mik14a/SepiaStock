using System;

using SepiaStock.Unity.Presenters;

using UnityEngine;

public class PhotoSelectController : MonoBehaviour
{
    void Awake()
    {
        _headerView = FindObjectOfType<HeaderView>();
        _headerPresenter = HeaderPresenter.CreateInstance(_headerView);
        _headerPresenter.OnBack += Back;
        _sceneView = FindObjectOfType<PhotoSelectView>();
        _scenePresenter = PhotoSelectPresenter.CreateInstance(_sceneView);
        _scenePresenter.OnNext += Next;
    }

    void Start()
    {
        _headerPresenter.Initialize();
        _scenePresenter.Initialize();
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

    HeaderView _headerView;
    PhotoSelectView _sceneView;

    HeaderPresenter _headerPresenter;
    PhotoSelectPresenter _scenePresenter;
}
