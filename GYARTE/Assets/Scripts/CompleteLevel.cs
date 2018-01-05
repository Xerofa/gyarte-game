using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompleteLevel: MonoBehaviour {
    #region Variables
    public string menuSceneName;
    public SceneFader sceneFader;
    public string levelSelector;
    public int levelToUnlock;
    public Text scoreText;
    #endregion

    void Awake()
    {
        scoreText.text = "Score: " + Points.amountPickedUp.ToString();
    }
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