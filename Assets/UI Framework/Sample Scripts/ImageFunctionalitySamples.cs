using UnityEngine;
using System.Collections;

public class ImageFunctionalitySamples : UI_Screen {

    // Because this will be an open sourced package make sure you 
    // add extra KeyCode(s) to allow users to play around with the functionality.
    // TODO: Add more KeyCodes
    public KeyCode imageFillKeyCode = KeyCode.A;

    // TODO: Add more public string names
    // If you create another image for image color functionality make a new public 
    // string with that Image's name. Also remove this comment.
    public string barName = "Health Bar";

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
	}
}
