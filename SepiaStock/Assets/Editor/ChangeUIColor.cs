#if UNITY_EDITOR

using System.Linq;

using UnityEditor;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is used to change the UI color in the Unity Editor.
/// </summary>
public class ChangeUIColor : EditorWindow
{
    [MenuItem("Window/Change UI Color")]
    /// <summary>
    /// Show the window for changing UI color.
    /// </summary>
    public static void ShowWindow()
    {
        GetWindow<ChangeUIColor>("Change UI Color");
    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// </summary>
    void OnGUI()
    {
        _foldoutTextColor = EditorGUILayout.Foldout(_foldoutTextColor, "Set the new color for UI elements");
        if (_foldoutTextColor) {
            _textColor = EditorGUILayout.ColorField("Text Color", _textColor);
        }

        _foldoutButtonColor = EditorGUILayout.Foldout(_foldoutButtonColor, "Set the new Button elements");
        if (_foldoutButtonColor) {
            _buttonColor = EditorGUILayout.ColorField("Button Color", _buttonColor);
            _buttonHighlightColor = EditorGUILayout.ColorField("Button Highlight Color", _buttonHighlightColor);
            _buttonPressedColor = EditorGUILayout.ColorField("Button Pressed Color", _buttonPressedColor);
            _buttonDisabledColor = EditorGUILayout.ColorField("Button Disabled Color", _buttonDisabledColor);
            _buttonSelectedColor = EditorGUILayout.ColorField("Button Selected Color", _buttonSelectedColor);
        }

        _foldoutSliderColor = EditorGUILayout.Foldout(_foldoutSliderColor, "Set the new Slider elements");
        if (_foldoutSliderColor) {
            _sliderColor = EditorGUILayout.ColorField("Slider Color", _sliderColor);
            _sliderHighlightColor = EditorGUILayout.ColorField("Slider Highlight Color", _sliderHighlightColor);
            _sliderPressedColor = EditorGUILayout.ColorField("Slider Pressed Color", _sliderPressedColor);
            _sliderDisabledColor = EditorGUILayout.ColorField("Slider Disabled Color", _sliderDisabledColor);
            _sliderFillColor = EditorGUILayout.ColorField("Slider Fill Color", _sliderFillColor);
            _sliderSelectedColor = EditorGUILayout.ColorField("Slider Selected Color", _sliderSelectedColor);
        }

        _foldoutToggleColor = EditorGUILayout.Foldout(_foldoutToggleColor, "Set the new Toggle elements");
        if (_foldoutToggleColor) {
            _toggleColor = EditorGUILayout.ColorField("Toggle Color", _toggleColor);
            _toggleHighlightColor = EditorGUILayout.ColorField("Toggle Highlight Color", _toggleHighlightColor);
            _togglePressedColor = EditorGUILayout.ColorField("Toggle Pressed Color", _togglePressedColor);
            _toggleDisabledColor = EditorGUILayout.ColorField("Toggle Disabled Color", _toggleDisabledColor);
            _toggleSelectedColor = EditorGUILayout.ColorField("Toggle Selected Color", _toggleSelectedColor);
        }

        _foldoutDropdownColor = EditorGUILayout.Foldout(_foldoutDropdownColor, "Set the new Dropdown elements");
        if (_foldoutDropdownColor) {
            _dropdownColor = EditorGUILayout.ColorField("Dropdown Color", _dropdownColor);
            _dropdownHighlightColor = EditorGUILayout.ColorField("Dropdown Highlight Color", _dropdownHighlightColor);
            _dropdownPressedColor = EditorGUILayout.ColorField("Dropdown Pressed Color", _dropdownPressedColor);
            _dropdownDisabledColor = EditorGUILayout.ColorField("Dropdown Disabled Color", _dropdownDisabledColor);
            _dropdownSelectedColor = EditorGUILayout.ColorField("Dropdown Selected Color", _dropdownSelectedColor);
        }

        _foldoutInputFieldColor = EditorGUILayout.Foldout(_foldoutInputFieldColor, "Set the new Input Field elements");
        if (_foldoutInputFieldColor) {
            _inputFieldColor = EditorGUILayout.ColorField("Input Field Color", _inputFieldColor);
            _inputFieldHighlightColor = EditorGUILayout.ColorField("Input Field Highlight Color", _inputFieldHighlightColor);
            _inputFieldPressedColor = EditorGUILayout.ColorField("Input Field Pressed Color", _inputFieldPressedColor);
            _inputFieldDisabledColor = EditorGUILayout.ColorField("Input Field Disabled Color", _inputFieldDisabledColor);
            _inputFieldSelectedColor = EditorGUILayout.ColorField("Input Field Selected Color", _inputFieldSelectedColor);
        }

        _foldoutScrollbarColor = EditorGUILayout.Foldout(_foldoutScrollbarColor, "Set the new Scrollbar elements");
        if (_foldoutScrollbarColor) {
            _scrollbarColor = EditorGUILayout.ColorField("Scrollbar Color", _scrollbarColor);
            _scrollbarHighlightColor = EditorGUILayout.ColorField("Scrollbar Highlight Color", _scrollbarHighlightColor);
            _scrollbarPressedColor = EditorGUILayout.ColorField("Scrollbar Pressed Color", _scrollbarPressedColor);
            _scrollbarDisabledColor = EditorGUILayout.ColorField("Scrollbar Disabled Color", _scrollbarDisabledColor);
            _scrollbarImageColor = EditorGUILayout.ColorField("Scrollbar Image Color", _scrollbarImageColor);
            _scrollbarSelectedColor = EditorGUILayout.ColorField("Scrollbar Selected Color", _scrollbarSelectedColor);
        }

        _foldoutScrollRectColor = EditorGUILayout.Foldout(_foldoutScrollRectColor, "Set the new Scroll Rect elements");
        if (_foldoutScrollRectColor) {
            _scrollRectColor = EditorGUILayout.ColorField("Scroll Rect Color", _scrollRectColor);
        }

        if (GUILayout.Button("Change Color")) {
            Undo.RecordObject(this, "Change UI Color");
            ChangeColorInTextElements(_textColor);
            ChangeColorInButtonElements(_buttonColor, _buttonHighlightColor, _buttonPressedColor, _buttonDisabledColor, _buttonSelectedColor);
            ChangeColorInSliderElements(_sliderColor, _sliderHighlightColor, _sliderPressedColor, _sliderDisabledColor, _sliderFillColor, _sliderSelectedColor);
            ChangeColorInToggleElements(_toggleColor, _toggleHighlightColor, _togglePressedColor, _toggleDisabledColor, _toggleSelectedColor);
            ChangeColorInDropdownElements(_dropdownColor, _dropdownHighlightColor, _dropdownPressedColor, _dropdownDisabledColor, _dropdownSelectedColor);
            ChangeColorInInputFieldElements(_inputFieldColor, _inputFieldHighlightColor, _inputFieldPressedColor, _inputFieldDisabledColor, _inputFieldSelectedColor);
            ChangeColorInScrollbarElements(_scrollbarColor, _scrollbarHighlightColor, _scrollbarPressedColor, _scrollbarDisabledColor, _scrollbarImageColor, _scrollbarSelectedColor);
            ChangeColorInScrollRectElements(_scrollRectColor);
        }
    }

    /// <summary>
    /// Change the color in text elements.
    /// </summary>
    /// <param name="color">The new color.</param>
    static void ChangeColorInTextElements(Color color)
    {
        foreach (var textElement in Resources.FindObjectsOfTypeAll(typeof(Text)).Cast<Text>()) {
            Undo.RecordObject(textElement, "Change Text Color");
            textElement.color = color;
        }
    }

    /// <summary>
    /// Change the color in image elements.
    /// </summary>
    /// <param name="color">The new color.</param>
    static void ChangeColorInImageElements(Color color)
    {
        foreach (var imageElement in Resources.FindObjectsOfTypeAll(typeof(Image)).Cast<Image>()) {
            Undo.RecordObject(imageElement, "Change Image Color");
            imageElement.color = color;
        }
    }

    /// <summary>
    /// Change the color in button elements.
    /// </summary>
    /// <param name="color">The new color.</param>
    /// <param name="highlightColor">The new highlight color.</param>
    /// <param name="pressedColor">The new pressed color.</param>
    /// <param name="disabledColor">The new disabled color.</param>
    /// <param name="selectedColor">The new selected color.</param>
    static void ChangeColorInButtonElements(Color color, Color highlightColor, Color pressedColor, Color disabledColor, Color selectedColor)
    {
        foreach (var buttonElement in Resources.FindObjectsOfTypeAll(typeof(Button)).Cast<Button>()) {
            Undo.RecordObject(buttonElement, "Change Button Color");
            var colors = buttonElement.colors;
            colors.normalColor = color;
            colors.highlightedColor = highlightColor;
            colors.pressedColor = pressedColor;
            colors.disabledColor = disabledColor;
            colors.selectedColor = selectedColor;
            buttonElement.colors = colors;
        }
    }

    /// <summary>
    /// Change the color in slider elements.
    /// </summary>
    /// <param name="color">The new color.</param>
    /// <param name="highlightColor">The new highlight color.</param>
    /// <param name="pressedColor">The new pressed color.</param>
    /// <param name="disabledColor">The new disabled color.</param>
    /// <param name="fillColor">The new fill color.</param>
    /// <param name="selectedColor">The new selected color.</param>
    static void ChangeColorInSliderElements(Color color, Color highlightColor, Color pressedColor, Color disabledColor, Color fillColor, Color selectedColor)
    {
        foreach (var sliderElement in Resources.FindObjectsOfTypeAll(typeof(Slider)).Cast<Slider>()) {
            Undo.RecordObject(sliderElement, "Change Slider Color");
            var colors = sliderElement.colors;
            colors.normalColor = color;
            colors.highlightedColor = highlightColor;
            colors.pressedColor = pressedColor;
            colors.disabledColor = disabledColor;
            colors.selectedColor = selectedColor;
            sliderElement.colors = colors;
            if (sliderElement.fillRect != null) {
                Undo.RecordObject(sliderElement.fillRect.GetComponent<Image>(), "Change Slider Fill Color");
                sliderElement.fillRect.GetComponent<Image>().color = fillColor;
            }
        }
    }

    /// <summary>
    /// Change the color in toggle elements.
    /// </summary>
    /// <param name="color">The new color.</param>
    /// <param name="highlightColor">The new highlight color.</param>
    /// <param name="pressedColor">The new pressed color.</param>
    /// <param name="disabledColor">The new disabled color.</param>
    /// <param name="selectedColor">The new selected color.</param>
    static void ChangeColorInToggleElements(Color color, Color highlightColor, Color pressedColor, Color disabledColor, Color selectedColor)
    {
        foreach (var toggleElement in Resources.FindObjectsOfTypeAll(typeof(Toggle)).Cast<Toggle>()) {
            Undo.RecordObject(toggleElement, "Change Toggle Color");
            var colors = toggleElement.colors;
            colors.normalColor = color;
            colors.highlightedColor = highlightColor;
            colors.pressedColor = pressedColor;
            colors.disabledColor = disabledColor;
            colors.selectedColor = selectedColor;
            toggleElement.colors = colors;
        }
    }

    /// <summary>
    /// Change the color in dropdown elements.
    /// </summary>
    /// <param name="color">The new color.</param>
    /// <param name="highlightColor">The new highlight color.</param>
    /// <param name="pressedColor">The new pressed color.</param>
    /// <param name="disabledColor">The new disabled color.</param>
    /// <param name="selectedColor">The new selected color.</param>
    static void ChangeColorInDropdownElements(Color color, Color highlightColor, Color pressedColor, Color disabledColor, Color selectedColor)
    {
        foreach (var dropdownElement in Resources.FindObjectsOfTypeAll(typeof(Dropdown)).Cast<Dropdown>()) {
            Undo.RecordObject(dropdownElement, "Change Dropdown Color");
            var colors = dropdownElement.colors;
            colors.normalColor = color;
            colors.highlightedColor = highlightColor;
            colors.pressedColor = pressedColor;
            colors.disabledColor = disabledColor;
            colors.selectedColor = selectedColor;
            dropdownElement.colors = colors;
        }
    }

    /// <summary>
    /// Change the color in input field elements.
    /// </summary>
    /// <param name="color">The new color.</param>
    /// <param name="highlightColor">The new highlight color.</param>
    /// <param name="pressedColor">The new pressed color.</param>
    /// <param name="disabledColor">The new disabled color.</param>
    /// <param name="selectedColor">The new selected color.</param>
    static void ChangeColorInInputFieldElements(Color color, Color highlightColor, Color pressedColor, Color disabledColor, Color selectedColor)
    {
        foreach (var inputFieldElement in Resources.FindObjectsOfTypeAll(typeof(InputField)).Cast<InputField>()) {
            Undo.RecordObject(inputFieldElement, "Change Input Field Color");
            var colors = inputFieldElement.colors;
            colors.normalColor = color;
            colors.highlightedColor = highlightColor;
            colors.pressedColor = pressedColor;
            colors.disabledColor = disabledColor;
            colors.selectedColor = selectedColor;
            inputFieldElement.colors = colors;
        }
    }

    /// <summary>
    /// Change the color in scrollbar elements.
    /// </summary>
    /// <param name="color">The new color.</param>
    /// <param name="highlightColor">The new highlight color.</param>
    /// <param name="pressedColor">The new pressed color.</param>
    /// <param name="disabledColor">The new disabled color.</param>
    /// <param name="imageColor">The new image color.</param>
    /// <param name="selectedColor">The new selected color.</param>
    static void ChangeColorInScrollbarElements(Color color, Color highlightColor, Color pressedColor, Color disabledColor, Color imageColor, Color selectedColor)
    {
        foreach (var scrollbarElement in Resources.FindObjectsOfTypeAll(typeof(Scrollbar)).Cast<Scrollbar>()) {
            Undo.RecordObject(scrollbarElement, "Change Scrollbar Color");
            var colors = scrollbarElement.colors;
            colors.normalColor = color;
            colors.highlightedColor = highlightColor;
            colors.pressedColor = pressedColor;
            colors.disabledColor = disabledColor;
            colors.selectedColor = selectedColor;
            scrollbarElement.colors = colors;
            if (scrollbarElement.GetComponent<Image>() != null) {
                Undo.RecordObject(scrollbarElement.GetComponent<Image>(), "Change Scrollbar Image Color");
                scrollbarElement.GetComponent<Image>().color = imageColor;
            }
        }
    }

    /// <summary>
    /// Change the color in scroll rect elements.
    /// </summary>
    /// <param name="color">The new color.</param>
    static void ChangeColorInScrollRectElements(Color color)
    {
        foreach (var scrollViewElement in Resources.FindObjectsOfTypeAll(typeof(ScrollRect)).Cast<ScrollRect>()) {
            Undo.RecordObject(scrollViewElement, "Change Scroll Rect Color");
            if (scrollViewElement.GetComponent<Image>() != null) {
                Undo.RecordObject(scrollViewElement.GetComponent<Image>(), "Change Scroll Rect Image Color");
                scrollViewElement.GetComponent<Image>().color = color;
            }
        }
    }

    bool _foldoutTextColor = true;
    Color _textColor = new(220 / 255f, 220 / 255f, 220 / 255f, 1);
    bool _foldoutButtonColor = true;
    Color _buttonColor = new(76 / 255f, 76 / 255f, 76 / 255f, 1);
    Color _buttonHighlightColor = new(255 / 255f, 105 / 255f, 180 / 255f, 1); // ピンク
    Color _buttonPressedColor = new(255 / 255f, 20 / 255f, 147 / 255f, 1); // ディープピンク
    Color _buttonDisabledColor = new(255 / 255f, 192 / 255f, 203 / 255f, 1); // ライトピンク
    Color _buttonSelectedColor = new(219 / 255f, 112 / 255f, 147 / 255f, 1); // ペールヴァイオレットレッド
    bool _foldoutSliderColor = true;
    Color _sliderColor = new(76 / 255f, 76 / 255f, 76 / 255f, 1);
    Color _sliderHighlightColor = new(255 / 255f, 105 / 255f, 180 / 255f, 1); // ピンク
    Color _sliderPressedColor = new(255 / 255f, 20 / 255f, 147 / 255f, 1); // ディープピンク
    Color _sliderDisabledColor = new(255 / 255f, 192 / 255f, 203 / 255f, 1); // ライトピンク
    Color _sliderFillColor = new(153 / 255f, 153 / 255f, 153 / 255f, 1);
    Color _sliderSelectedColor = new(219 / 255f, 112 / 255f, 147 / 255f, 1); // ペールヴァイオレットレッド
    bool _foldoutToggleColor = true;
    Color _toggleColor = new(76 / 255f, 76 / 255f, 76 / 255f, 1);
    Color _toggleHighlightColor = new(255 / 255f, 105 / 255f, 180 / 255f, 1); // ピンク
    Color _togglePressedColor = new(255 / 255f, 20 / 255f, 147 / 255f, 1); // ディープピンク
    Color _toggleDisabledColor = new(255 / 255f, 192 / 255f, 203 / 255f, 1); // ライトピンク
    Color _toggleSelectedColor = new(219 / 255f, 112 / 255f, 147 / 255f, 1); // ペールヴァイオレットレッド
    bool _foldoutDropdownColor = true;
    Color _dropdownColor = new(76 / 255f, 76 / 255f, 76 / 255f, 1);
    Color _dropdownHighlightColor = new(255 / 255f, 105 / 255f, 180 / 255f, 1); // ピンク
    Color _dropdownPressedColor = new(255 / 255f, 20 / 255f, 147 / 255f, 1); // ディープピンク
    Color _dropdownDisabledColor = new(255 / 255f, 192 / 255f, 203 / 255f, 1); // ライトピンク
    Color _dropdownSelectedColor = new(219 / 255f, 112 / 255f, 147 / 255f, 1); // ペールヴァイオレットレッド
    bool _foldoutInputFieldColor = true;
    Color _inputFieldColor = new(76 / 255f, 76 / 255f, 76 / 255f, 1);
    Color _inputFieldHighlightColor = new(255 / 255f, 105 / 255f, 180 / 255f, 1); // ピンク
    Color _inputFieldPressedColor = new(255 / 255f, 20 / 255f, 147 / 255f, 1); // ディープピンク
    Color _inputFieldDisabledColor = new(255 / 255f, 192 / 255f, 203 / 255f, 1); // ライトピンク
    Color _inputFieldSelectedColor = new(219 / 255f, 112 / 255f, 147 / 255f, 1); // ペールヴァイオレットレッド
    bool _foldoutScrollbarColor = true;
    Color _scrollbarColor = new(76 / 255f, 76 / 255f, 76 / 255f, 1);
    Color _scrollbarHighlightColor = new(255 / 255f, 105 / 255f, 180 / 255f, 1); // ピンク
    Color _scrollbarPressedColor = new(255 / 255f, 20 / 255f, 147 / 255f, 1); // ディープピンク
    Color _scrollbarDisabledColor = new(255 / 255f, 192 / 255f, 203 / 255f, 1); // ライトピンク
    Color _scrollbarSelectedColor = new(219 / 255f, 112 / 255f, 147 / 255f, 1); // ペールヴァイオレットレッド
    Color _scrollbarImageColor = new(76 / 255f, 76 / 255f, 76 / 255f, 1);
    bool _foldoutScrollRectColor = true;
    Color _scrollRectColor = new(76 / 255f, 76 / 255f, 76 / 255f, 1);
}
#endif
