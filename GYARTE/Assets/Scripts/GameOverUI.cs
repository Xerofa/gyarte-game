using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI: MonoBehaviour {
    #region Variables
    public SceneFader sceneFader;
    public string menuSceneName;
    [Header("Misc")]
    public AudioManager aM;
    #endregion

    void Start()
    {
        aM = GetComponent<AudioManager>();
        aM = FindObjectOfType<AudioManager>();
    }
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
        aM.Play("Theme");
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}