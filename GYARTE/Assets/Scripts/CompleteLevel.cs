using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel: MonoBehaviour {
    #region Variables
    public string menuSceneName;
    public SceneFader sceneFader;
    public string levelSelector;
    public int levelToUnlock;
    #endregion
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }

    public void Continue()
    {
        Debug.Log("Go to level selector");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(levelSelector);
    }

}