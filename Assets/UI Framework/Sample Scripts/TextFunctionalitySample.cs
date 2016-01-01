using UnityEngine;
using System.Collections;

public class TextFunctionalitySample : UIScreen {

    public string textField;
    public string progressiveTextField;
    public string[] sampleText;
    public string rollingText;

    public KeyCode stringInput = KeyCode.V;
    public KeyCode rollingInput = KeyCode.K;
    public KeyCode interruptInput = KeyCode.Space;

    protected override void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp(stringInput)) {
            SetText(textField, sampleText[(int)Random.Range(0, 2)]);
        }
        if (Input.GetKeyUp(rollingInput))
        {
            StartCoroutine(TextProgression(progressiveTextField, rollingText, interruptInput));      
        }
	}
}
