using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour {
    #region Variables
    public string levelSelector;
    public string controlsSelector;
    public SceneFader sceneFader;
    #endregion

 public void Play()
    {
       sceneFader.FadeTo(levelSelector);
        Debug.Log("Go to LEVELSELECTOR");
    }

    public void Controls()
    {
        sceneFader.FadeTo(controlsSelector);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit the game");
    }

}