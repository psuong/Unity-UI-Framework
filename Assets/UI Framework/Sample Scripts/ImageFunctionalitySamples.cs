using UnityEngine;

public class ImageFunctionalitySamples : UIScreen {

    // Because this will be an open sourced package make sure you 
    // add extra KeyCode(s) to allow users to play around with the functionality.
    public string barName = "Health Bar"; // Name of an Image Component
    public KeyCode imageFillKeyCode = KeyCode.A; // Button to press, that randomly sets an image's fill value
    public KeyCode imageColorKeyCode = KeyCode.B; // Button to press, that randomly sets a color
    public KeyCode imageColorDefaultKeyCode = KeyCode.D; // Button to press that changes the color back to it's default color.

    void Update () {
        if (Input.GetKeyDown(imageFillKeyCode))
            SetImageFill(barName, Random.Range(0f, 1f));
        if (Input.GetKeyDown(imageColorKeyCode))
            SetImageColor(barName, Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        if (Input.GetKeyDown(imageColorDefaultKeyCode))
            SetImageColor(barName, Color.cyan);
    }
}
