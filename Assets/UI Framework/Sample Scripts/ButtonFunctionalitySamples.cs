using UnityEngine;


public class ButtonFunctionalitySamples : UIScreen {
    public string buttonName = "Test Button";
    public string sampleChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ-abcdefghijkmlnopqrstuvwxyz";
    public string sample_string = "";

    public KeyCode buttonInput = KeyCode.O;

    private string GenerateString(int stringSize)
    {
        sample_string = null;
        for (int i =0; i < stringSize; i++)
        {
            int index = Random.Range(0, sampleChars.Length);
            char textchar = sampleChars[index];
            sample_string += textchar;
        }
        return sample_string;
    }

	
	void Update () {
    if (Input.GetKeyDown(buttonInput))
        {
            SetButton(buttonName, GenerateString(5) );
        }        
	
	}
}
