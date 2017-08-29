using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI: MonoBehaviour {
    #region Variables
    public SceneFader sceneFader;
    public string menuSceneName;
    #endregion


    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        GameManager.remainingLives = 3;
        //Debug.Log(GameManager.remainingLives);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}