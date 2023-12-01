using System;

using SepiaStock.Views;

using UnityEngine;
using UnityEngine.UI;

public class HeaderView : MonoBehaviour, IHeaderView
{
    [SerializeField]
    Button _backButton;

    public event Action OnBack;

    void Awake()
    {
        _backButton.onClick.AddListener(() => OnBack?.Invoke());
    }
}
