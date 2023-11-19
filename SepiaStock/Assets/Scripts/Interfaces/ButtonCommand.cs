using System;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
class ButtonCommand<T>
{
    [SerializeField, ReadOnly]
    T _key;

    [SerializeField]
    Button _button;

    [SerializeField]
    UnityAction _call;

    public ButtonCommand(T key)
    {
        _key = key;
    }

    public void OnClick(UnityAction call)
    {
        _button.onClick.AddListener(call);
    }
}
