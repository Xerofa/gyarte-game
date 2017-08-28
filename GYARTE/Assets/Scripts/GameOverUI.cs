using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI: MonoBehaviour {
    #region Variables

    #endregion


    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}