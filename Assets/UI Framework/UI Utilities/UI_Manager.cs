using UnityEngine;
using System.Collections;
using Utilities.Singleton;

public class UI_Manager : Singleton<UI_Manager> {

    // Stores all components of type screen
    UI_Screen[] screens;

    protected override void OnAwake() {
        // Gets all children components with UI_Screen, even inactive ones
        screens = GetComponentsInChildren<UI_Screen>(true);
        for (int i = 0; i < screens.Length; i++) {
            screens[i].SetUp();
        }
    }

    #region Open and Close Screens
    /// <summary>
    /// ODefault method for Unity to catch the method. Activates 
    /// the instance the Screen and deactivates every other UI Screen
    /// Component.
    /// </summary>
    /// <param name="name">name of the UI Screen</param>
    public void OpenScreen(string name) {
        OpenScreen(name, true);
    }

    /// <summary>
    /// Activates an instance of UI_Screen and can close 
    /// all other instances of UI_Screen.
    /// </summary>
    /// <param name="name">Name of the gameObject with a UI_Screen Component</param>
    /// <param name="canCloseAll">Should all other screens be closed?</param>
    public void OpenScreen(string name, bool canCloseAll=true) {
        GetScreen(name).OpenThisScreen();
        if (canCloseAll) {
            for (int i = 0; i < screens.Length; i++) {
                if (screens[i].name != name)
                    screens[i].CloseThisScreen();
            }
        }
    }

    /// <summary>
    /// Deactivates all instances of UI_Screen.
    /// </summary>
    public void CloseAllScreens() {
        for (int i = 0; i < screens.Length; i++) {
            screens[i].CloseThisScreen();
        }
    }
    #endregion

    #region Getters
    /// <summary>
    /// Returns an instance of UI Screen
    /// </summary>
    /// <param name="name">Name of the screen to return</param>
    /// <returns>Null if no screen is found</returns>
    private UI_Screen GetScreen(string name) {
        for (int i = 0; i < screens.Length; i++) {
            if (screens[i].name == name)
                return screens[i];
        }
        return null;
    }
    #endregion
}
