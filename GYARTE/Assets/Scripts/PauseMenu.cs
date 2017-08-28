using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu: MonoBehaviour {
    #region Variables
    public GameObject ui;
    public GameObject pRA;
    #endregion

 void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
            pRA.GetComponent<PlayerRangedAttack>().enabled = false;
        }
        else
        {
            Time.timeScale = 1f;
            pRA.GetComponent<PlayerRangedAttack>().enabled = true;
        }
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Go to menu");
    }

    public void Quit()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

}