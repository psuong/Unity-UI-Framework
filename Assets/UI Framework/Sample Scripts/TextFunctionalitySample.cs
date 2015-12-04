using UnityEngine;
using System.Collections;

public class TextFunctionalitySample : UI_Screen {

    public string textField;
    public string[] sampleText;

    public KeyCode stringInput = KeyCode.V;

    protected override void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp(stringInput)) {
            SetText(textField, sampleText[(int)Random.Range(0, 2)]);
        }
	
	}
}
