using UnityEngine;

public class TextFunctionalitySample : UIScreen {

    public string titleName = "Screen 2 Title text"; // Name of a Text component
    public string progressiveTextField = "Sample Text 3"; // Name of a different Text component
    public string rollingText; // Text you would like to see progressively grow (similar to typing)
    public string[] sampleText; // Bunch of sample texts to randomly set
    public KeyCode stringInput = KeyCode.V; // Button to press
    public KeyCode rollingInput = KeyCode.K; // Button to press
    public KeyCode interruptInput = KeyCode.Space; // Button to press

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp(stringInput)) 
            SetText(titleName, sampleText[(int)Random.Range(0, 2)]);
        if (Input.GetKeyUp(rollingInput)) 
            StartCoroutine(TextProgression(progressiveTextField, rollingText, interruptInput));      
	}
}
