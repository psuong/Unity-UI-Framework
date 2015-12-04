using UnityEngine;
using System.Collections;

public class ImageFunctionalitySamples : UI_Screen {

    // Because this will be an open sourced package make sure you 
    // add extra KeyCode(s) to allow users to play around with the functionality.
    // TODO: Add more KeyCodes
    public KeyCode imageFillKeyCode = KeyCode.A;
    public KeyCode imageColorKeyCode = KeyCode.B;
    public KeyCode imageColorDefaultKeyCode = KeyCode.D;

    public string barName = "Health Bar";

    // Use this for initialization
    protected override void Start() {
        base.Start();
    }

    /// <summary>
    /// Update is called once per frame,
    /// press imageFillKeyCode to Update the Health Bar fill.
    /// press imageColorKeyCode to alter the color of the Health
    /// </summary>
    void Update () {
        if (Input.GetKeyDown(imageFillKeyCode))
            SetImageFill(barName, Random.Range(0f, 1f));
        if (Input.GetKeyDown(imageColorKeyCode))
        {
            SetImageColor(barName, Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
        if (Input.GetKeyDown(imageColorDefaultKeyCode))
            SetImageColor(barName, Color.cyan);
    }
}
