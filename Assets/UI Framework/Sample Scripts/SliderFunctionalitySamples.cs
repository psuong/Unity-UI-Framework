using UnityEngine;
using UnityEngine.UI;

public class SliderFunctionalitySamples : UIScreen {

    public KeyCode sliderFillInput = KeyCode.S; // Button to press
    public string sliderName = "Test Slider"; // the identifier of the slider referenced
    public string textValueName = "Slider Value"; // The identifier of the text referenced
    private Slider slider; // Private reference to the slider on this screen
    
    // Use this for initialization. 
    protected override void Start() {
        base.Start();
        slider = GetSlider(sliderName);
        GetText(textValueName).text = GetSlider(sliderName).minValue.ToString();
    }
    
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(sliderFillInput))
            SetSliderFill(sliderName, Random.Range(GetSlider(sliderName).minValue, GetSlider(sliderName).maxValue));
        SetText(textValueName, slider.value.ToString());
    }
}
