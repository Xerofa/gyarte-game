using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu: MonoBehaviour {
    #region Variables
    public GameObject ui;
    public GameObject pRA;
    public string mainMenuLevel;
    public SceneFader sceneFader;
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
            if (pRA == null)
                return;
            else
            {
            pRA.GetComponent<PlayerRangedAttack>().enabled = false;
            }
        }
        else
        {
            Time.timeScale = 1f;
            if (pRA == null)
                return;
            else
            {
            pRA.GetComponent<PlayerRangedAttack>().enabled = true;
            }
        }
    }

    public void Restart()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(mainMenuLevel);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

}