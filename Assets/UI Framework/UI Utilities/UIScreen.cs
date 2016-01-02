using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// UIScreen contains dictionaries which keeps references to all Text, Slider, Image.
/// </summary>
public class UIScreen : MonoBehaviour {
    // Stores all references of Unity's Text, Image, and Slider Components
    protected Dictionary<string, Text> textDict;
    protected Dictionary<string, Image> imageDict;
    protected Dictionary<string, Slider> sliderDict;

    /// <summary>
    /// Unity's Start() method; this checks to see if the dictionaries 
    /// are built up, if not then it builds up the dictionaries.
    /// </summary>
	protected virtual void Start () {
	    if (textDict == null || imageDict == null || sliderDict == null) {
            SetUp();
        }
    }

    /// <summary>
    /// Populates the dictionaries with references to all Text,
    /// Image, and Slider components within the scene.
    /// </summary>
    public void SetUp() {
        textDict = new Dictionary<string, Text>();
        imageDict = new Dictionary<string, Image>();
        sliderDict = new Dictionary<string, Slider>();

        Text[] textElements = GetComponentsInChildren<Text>(true);
        Image[] imageElements = GetComponentsInChildren<Image>(true);
        Slider[] sliderElements = GetComponentsInChildren<Slider>(true);
        
        SetUpTextDict(textElements);
        SetUpImageDict(imageElements);
        SetUpSliderDict(sliderElements);
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
            Debug.LogError(imageName + " is not in dictionary");
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
    /// <param name="a">Float value between 0 and 1 for the alpha component</param>
    public void SetImageColor(string imageName, float r, float g, float b, float a = 1) {
        if (imageDict.ContainsKey(imageName) && r <= 1 && r>= 0 && g <= 1 && g >= 0 && b <= 1 && b >= 0 && a <= 1 && a >= 0)
            imageDict[imageName].color = new Color(r, g, b, a);
        else
        {
            if(!imageDict.ContainsKey(imageName))
                Debug.LogError(imageName + " is not in dictionary");
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
    public void SetImageColor(string imageName, Color setColor) {
        if (imageDict.ContainsKey(imageName))
            imageDict[imageName].color = setColor;
        else
            Debug.LogError(imageName + " is not in dictionary!");
    }
    #endregion

    #region Set Text
    /// <summary>
    /// Sets the text variable in the Text gameObject to a custom
    /// string.
    /// </summary>
    /// <param name="textName">Name of the Text Component</param>
    /// <param name="screenText">The string to display</param>
    public void SetText(string textName, string screenText) {
        if (textDict.ContainsKey(textName)) {
            textDict[textName].text = screenText;
        }
        else {
            Debug.LogError(textName + " is not in dictionary!");
        }
    }
    
    /// <summary>
    /// Sets text to progress one letter at a time
    /// </summary>
    /// <param name="textName">Name of the Text Component</param>
    /// <param name="rollingText">The text to be displayed progressively</param>
    /// <param name="interruptKey">Set key to interrupt the coroutine and display the entire text</param>
    public System.Collections.IEnumerator TextProgression(string textName, string rollingText, KeyCode interruptKey) {
        if (textDict.ContainsKey(textName)) {
            for (int i = 0; i < rollingText.Length; i++) {
                textDict[textName].text += rollingText[i];
                if (Input.GetKeyUp(interruptKey)) {
                    StopCoroutine("TextProgression");
                    textDict[textName].text = rollingText;
                }
                else
                    yield return null;
            }
        }
        else {
            Debug.LogError(textName + " is not in dictionary!");
        }
    }
    #endregion

    #region Set Slider
    /// <summary>
    /// Sets the slider's fill value to the desired amount.
    /// </summary>
    /// <param name="sliderName">Name of the slider component</param>
    /// <param name="sliderValue">Float value between the min and the max values.</param>
    public void SetSliderFill(string sliderName, float sliderValue) {
        if (sliderDict.ContainsKey(sliderName)) {
            sliderDict[sliderName].value = sliderValue;
        }
        else {
            Debug.LogError(sliderName + " is not in dictionary!");
        }
    }

    /// <summary>
    /// Overloads the SetSliderFill method to take in whole numbers (integers)
    /// and set the value of the slider to that value.
    /// </summary>
    /// <param name="sliderName">Name of the slider component (string)</param>
    /// <param name="sliderValue">Integer value of the slider's value between the min and max values.</param>
    public void SetSliderFill(string sliderName, int sliderValue) {
        if (sliderDict.ContainsKey(sliderName)) {
            if (!sliderDict[sliderName].wholeNumbers) {
                Debug.LogError(sliderName + " whole number's field is not enabled!");
            }
            else
                sliderDict[sliderName].value = sliderValue;
        }
    }
    #endregion
    
    #region UI Getters
    /// <summary>
    /// Returns an instance of an image. 
    /// </summary>
    /// <param name="imageName">Name of the image gameObject</param>
    /// <returns>Image</returns>
    public Image GetImage(string imageName) {
        if (!imageDict.ContainsKey(imageName)) {
            Debug.LogError(imageName + " is not found in the dictionary!");
        }
        return imageDict[imageName];
    }
    
    /// <summary>
    /// Returns an instance of a slider.
    /// </summary>
    /// <param name="sliderName">Name of the slider gameObject</param>
    /// <returns>Slider</returns>
    public Slider GetSlider(string sliderName) {
        if (!sliderDict.ContainsKey(sliderName)) {
            Debug.LogError(sliderName + " is not found in the dictionary!");
        }
        return sliderDict[sliderName];
    }

    /// <summary>
    /// Returns an instance of a Text gameObject.
    /// </summary>
    /// <param name="textName">Name of the text gameObject.</param>
    /// <returns>Text</returns>
    public Text GetText(string textName) {
        if (!textDict.ContainsKey(textName)) {
            Debug.LogError(textName + " is not found in the dictionary!");
        }
        return textDict[textName];        
    }
    #endregion
    
    #region Private Set Up Methods
    /// <summary>
    /// Builds the textDict with keys as a unique Text Component's name and
    /// the value as the associated Text's object.  
    /// </summary>
    /// <param name="textList">An array of Text Components</param>
    private void SetUpTextDict(Text[] textList) {
        int counter = 0;
        for (int i = 0; i < textList.Length; i++) {
            // If the dictionary contains the key already then give the key and Text name
            // a unique ID.
            if (textDict.ContainsKey(textList[i].name)) {
                textList[i].name = textList[i].name + " " + counter;
                counter++;
            }
            textDict.Add(textList[i].name, textList[i]);
        }
    }
    
    /// <summary>
    /// Builds the imageDict with keys as a unique Image Component's name and
    /// value as the associated Image's object.
    /// </summary>
    /// <param name="imageList">An array of Image Components</param>
    private void SetUpImageDict(Image[] imageList) {
        int counter = 0;
        for (int i = 0; i < imageList.Length; i++) {
            if (imageDict.ContainsKey(imageList[i].name)) {
                imageList[i].name = imageList[i].name + " " + counter;
                counter++;
            }
            imageDict.Add(imageList[i].name, imageList[i]);
        }
    }
    
    /// <summary>
    /// Builds the sliderDict with keys as a unique Slider Component's name and
    /// value as the associated Slider's object.
    /// </summary>
    /// <param name="sliderList">An array of Slider Components</param>
    private void SetUpSliderDict(Slider[] sliderList) {
        int counter = 0;
        for (int i = 0; i < sliderList.Length; i++) {
            if (sliderDict.ContainsKey(sliderList[i].name)) {
                sliderList[i].name = sliderList[i].name + " " + counter;
                counter++;
            }
            sliderDict.Add(sliderList[i].name, sliderList[i]);
        }
    }
    #endregion
}
