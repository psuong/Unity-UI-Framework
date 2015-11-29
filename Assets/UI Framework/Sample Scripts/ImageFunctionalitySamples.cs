using UnityEngine;
using System.Collections;

public class ImageFunctionalitySamples : UI_Screen {


    public KeyCode imageFillKeyCode = KeyCode.A;
    public KeyCode sliderValueKeyCode = KeyCode.C;


    public string barName = "Health Bar";
    public string sliderName = "Test Slider";

    // Use this for initialization
    protected override void Start() {
        base.Start();
    }

    /// <summary>
    /// Update is called once per frame,
    /// press imageFillKeyCode to Update the Health Bar.
    /// press sliderValueKeyCode to change the value on the slider
    /// </summary>
    void Update () {
        if (Input.GetKeyDown(imageFillKeyCode))
            SetImageFill(barName, Random.Range(0f, 1f));

        if (Input.GetKeyDown(sliderValueKeyCode))
            SetSliderFill(sliderName, Random.Range(0f, 1f));
	}
}
