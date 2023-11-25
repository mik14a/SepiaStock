using System;

using UnityEngine;
using UnityEngine.UI;

class ConfigController : MonoBehaviour
{
    [SerializeField]
    Text _photoFolderPath;
    [SerializeField]
    Text _albumFolderPath;
    [SerializeField]
    Text _finalFolderPath;
    [SerializeField]
    Button _okButton;
    [SerializeField]
    Button _cancelButton;

    void Awake()
    {
        _okButton.onClick.AddListener(OkClick);
        _cancelButton.onClick.AddListener(CancelClick);
    }

    private void Update()
    {
        _commandManager.Execute();
    }

    void OkClick()
    {
        _commandManager.Push(new BackCommand());
    }

    void CancelClick()
    {
        _commandManager.Push(new BackCommand());
    }

    /// <summary>コマンドマネージャー</summary>
    readonly CommandManager _commandManager = new();
}
