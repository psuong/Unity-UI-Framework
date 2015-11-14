using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GUI_Screen : MonoBehaviour {

    protected Dictionary<string, Text> textDict;
    protected Dictionary<string, Image> imageDict;
    protected Dictionary<string, Slider> sliderDict;

    protected virtual void Start()
    {
        if (textDict == null || imageDict == null || sliderDict == null)
        {
            buildUIRefs();    
        }   
    }

    /// <summary>
    /// Builds the initial references to the Dictionaries
    /// if the dictionaries are null.
    /// Each dictionary corresponds with a UI Component:
    /// Image, Text, Slider
    /// </summary>
    public void buildUIRefs()
    {
        textDict = new Dictionary<string, Text>();
        imageDict = new Dictionary<string, Image>();
        sliderDict = new Dictionary<string, Slider>();

        Text[] textElements = GetComponentsInChildren<Text>();
        Image[] imageElements = GetComponentsInChildren<Image>();
        Slider[] sliderElements = GetComponentsInChildren<Slider>();

        for (int i = 0; i < textElements.Length; i++)
            textDict.Add(textElements[i].name, textElements[i]);

        for (int i = 0; i < imageElements.Length; i++)
            imageDict.Add(imageElements[i].name, imageElements[i]);

        for (int i = 0; i < sliderElements.Length; i++)
            sliderDict.Add(sliderElements[i].name, sliderElements[i]);
    }

    #region Open/Close UI Elements
    public void openElement()
    {
        gameObject.SetActive(true);
    }

    public void closeElement()
    {
        gameObject.SetActive(false);
    }
    #endregion

    #region Getters
    public Text getText(string name)
    {
        return textDict[name];
    }

    public Image getImage(string name)
    {
        return imageDict[name];
    }

    public Slider getSlider(string name)
    {
        return sliderDict[name];
    }
    #endregion

    #region Setters
    public void setText (string key, string text)
    {
        if (!textDict.ContainsKey(key))
        {
            Debug.LogError("The key: " + key + " does not exist in the Dictionary!");
            return;
        }
        else
            textDict[key].text = text;
    }

    public void setImageFill(string key, float value)
    {
        if (!imageDict.ContainsKey(key))
        {
            Debug.LogError("The key: " + key + " does not exist in the Dictionary!");
            return;
        }
        else
            imageDict[key].fillAmount = value;
    }

    public void setImageColor(string key, Color color)
    {
        if (!imageDict.ContainsKey(key))
        {
            Debug.LogError("The key: " + key + " does not exist in the Dictionary!");
            return;
        }
        else
            imageDict[key].color = color;
    }
    #endregion
}
