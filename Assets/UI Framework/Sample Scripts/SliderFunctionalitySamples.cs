using UnityEngine;
using System.Collections;

public class SliderFunctionalitySamples : UIScreen {

    public KeyCode sliderFillInput = KeyCode.S;
    
    public string sliderName = "Test Slider";
    
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(sliderFillInput)) {
            SetSliderFill(sliderName, Random.Range(GetSlider(sliderName).minValue, GetSlider(sliderName).maxValue));
        }
    }
}
