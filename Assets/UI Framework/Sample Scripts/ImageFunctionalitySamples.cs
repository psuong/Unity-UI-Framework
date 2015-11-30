using UnityEngine;
using System.Collections;

public class ImageFunctionalitySamples : UI_Screen {

    public KeyCode imageFillKeyCode = KeyCode.A;
    public KeyCode textKeyCode = KeyCode.D;

    
    public string barName = "Health Bar";
    public string testText = "Test Text";
    // Use this for initialization
    protected override void Start() {
        base.Start();
    }

    /// <summary>
    /// Update is called once per frame,
    /// press imageFillKeyCode to Update the Health Bar.
    /// </summary>
    void Update () {
        if (Input.GetKeyDown(imageFillKeyCode))
            SetImageFill(barName, Random.Range(0f, 1f));
        if (Input.GetKeyDown(textKeyCode))
            SetText(testText, "New Text");
	}
}
