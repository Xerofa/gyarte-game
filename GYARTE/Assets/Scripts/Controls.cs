using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls: MonoBehaviour {
    #region Variables
    public string mainMenuLevelToLoad;
    public SceneFader sceneFader;
    #endregion

 public void GoBackToMainMenu()
    {
        sceneFader.FadeTo(mainMenuLevelToLoad);
    }

}