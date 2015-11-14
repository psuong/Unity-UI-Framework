using UnityEngine;
using System.Collections;
using Utilities;

public class GUI_Manager : Singleton<GUI_Manager> {
    GUI_Screen[] screens;

    protected override void OnAwake()
    {
        screens = GetComponentsInChildren<GUI_Screen>(true);
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].buildUIRefs();
        }
    }

    #region Open/Close UI Elements
    public void openScreen(string name)
    {   

    }
    #endregion


}
