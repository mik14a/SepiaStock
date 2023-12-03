using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スケールファクターを制御するクラスです。
/// </summary>
public class ScaleFactorController : MonoBehaviour
{
    /// <summary>
    /// 初期化処理を行います。
    /// </summary>
    void Awake()
    {
        _canvasScaler = GetComponent<CanvasScaler>();
        _canvasScaler.scaleFactor = PlayerPrefs.GetFloat("scaleFactor", 1.0f);
    }

    /// <summary>
    /// 更新処理を行います。
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) {
            var scrollInput = Input.GetAxis("Mouse ScrollWheel");
            var delta = 0 < scrollInput ? 0.1f : scrollInput < 0 ? -0.1f : 0f;
            _canvasScaler.scaleFactor = Mathf.Clamp(_canvasScaler.scaleFactor + delta, 1f, 2f);
        }
    }

    /// <summary>
    /// 終了処理を行います。
    /// </summary>
    void OnDestroy()
    {
        PlayerPrefs.SetFloat("scaleFactor", _canvasScaler.scaleFactor);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// キャンバススケーラーの参照を保持します。
    /// </summary>
    CanvasScaler _canvasScaler;
}
