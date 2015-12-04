using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// UI_Screen contains dictionaries which keeps
/// references to all Text, Slider, Image
/// </summary>
public class UI_Screen : MonoBehaviour {

    protected Dictionary<string, Text> textDict;
    protected Dictionary<string, Image> imageDict;
    protected Dictionary<string, Slider> sliderDict;

    /// <summary>
    /// Unity's Start() method; this checks to see if
    /// the dictionaries are built up, if not then it builds up the
    /// dictionaries.
    /// </summary>
	protected virtual void Start () {
	    if (textDict == null || imageDict == null || sliderDict == null) {
            SetUp();
        }
    }

    /// <summary>
    /// Populates the dictionaries with references
    /// to all Text, Image, and Slider components within
    /// the scene.
    /// </summary>
    public void SetUp() {
        textDict = new Dictionary<string, Text>();
        imageDict = new Dictionary<string, Image>();
        sliderDict = new Dictionary<string, Slider>();

        Text[] textElements = GetComponentsInChildren<Text>(true);
        Image[] imageElements = GetComponentsInChildren<Image>(true);
        Slider[] sliderElements = GetComponentsInChildren<Slider>(true);

        for (int i = 0; i < textElements.Length; i++) {
            // Ignore text elements if the parent object has a component of type Button
            if (textElements[i].transform.parent.GetComponent<Button>() == null)
                textDict.Add(textElements[i].name, textElements[i]);
        }

        for (int i = 0; i < imageElements.Length; i++) {
            imageDict.Add(imageElements[i].name, imageElements[i]);
        }

        for (int i = 0; i < sliderElements.Length; i++) {
            sliderDict.Add(sliderElements[i].name, sliderElements[i]);
        }
    }

    #region Open and Close Screen
    /// <summary>
    /// Activates the instance of a gameObject 
    /// that UI_Screen is attached to.
    /// </summary>
    public void OpenThisScreen() { gameObject.SetActive(true); }

    /// <summary>
    /// Deactivates the instance of a gameObject
    /// that UI_Screen is attached to.
    /// </summary>
    public void CloseThisScreen() { gameObject.SetActive(false); }
    #endregion

    public void SetImageFill(string imageName, float fillValue) {
        if (imageDict.ContainsKey(imageName)) {
            imageDict[imageName].fillAmount = fillValue;
        }
        else {
            Debug.LogError("Image not in dictionary");
        }
    }

    #region Set Image Colors
    /// <summary>
    /// Takes in Unity's Color RGBA values as a float between 0 and 1
    /// and sets the ImageComponent to that color.
    /// </summary>
    /// <param name="imageName">Name of the Image Component</param>
    /// <param name="r">Float value between 0 and 1 for the red component</param>
    /// <param name="g">Float value between 0 and 1 for the green component</param>
    /// <param name="b">Float value between 0 and 1 for the blue component</param>
    /// <param name="a">FLaot value between 0 and 1 for the alpha component</param>
    public void SetImageColor(string imageName, float r, float g, float b, float a)
    {
        if (imageDict.ContainsKey(imageName) && r <= 1 && r>= 0 && g <= 1 && g >= 0 && b <= 1 && b >= 0 && a <= 1 && a >= 0)
        {
            imageDict[imageName].color = new Color(r, g, b, a);
        }
        else
        {
            if(!imageDict.ContainsKey(imageName))
                Debug.LogError("Image not in dictionary");
            else if (r > 1 || r < 0)
                Debug.LogError("r value is not within 0-1 range");
            else if (g > 1 || g < 0)
                Debug.LogError("g value is not within 0-1 range"); 
            else if (b > 1 || b < 0)
                Debug.LogError("b value is not within 0-1 range");
            else if (a > 1 || a < 0)
                Debug.LogError("a value is not within 0-1 range");
        }
    }

    /// <summary>
    /// Takes in a Unity's Color component and sets the Image Component
    /// to that that color.
    /// </summary>
    /// <param name="imageName">Name of the Image Component</param>
    /// <param name="setColor">Color value</param>
    public void SetImageColor(string imageName, Color setColor)
    {
        if (imageDict.ContainsKey(imageName))
            imageDict[imageName].color = setColor;
        else
            Debug.LogError("Image not in dictionary");
    }
    #endregion

    #region Set Text
    /// <summary>
    /// Set text with fontsize. If no fontsize is added, it is defaulted to size 25.
    /// </summary>
    /// <param name="textName">Name of the Text Component</param>
    /// <param name="screenText">The text to display</param>
    /// <param name="textSize">Size of the font</param>
    public void SetText(string textName, string screenText, float textSize = 25) {
        if (textDict.ContainsKey(textName)) {
            textDict[textName].text = screenText;
        }
        else {
            Debug.LogError("Text not in dictionary");
        }
    }
    #endregion

    #region Set Slider
    /// <summary>
    /// Can set the fill of the Slider. Value from 0-1
    /// </summary>
    /// <param name="sliderName">Name of the slider component</param>
    /// <param name="sliderValue">Float value between 0 and 1</param>
    public void SetSliderFill(string sliderName, float sliderValue) {
        if (sliderDict.ContainsKey(sliderName)) {
            sliderDict[sliderName].value = sliderValue;
        }
        else {
            Debug.LogError("Slider name not in dictionary");
        }
    }
    #endregion

    #region UI Getters

    #endregion
}
