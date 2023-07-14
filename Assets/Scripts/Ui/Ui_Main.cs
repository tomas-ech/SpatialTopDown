using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui_Main : MonoBehaviour
{
    private bool gamePaused;

    public void SwitchMenu(GameObject uiMenu)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        uiMenu.SetActive(true);

        AudioManager.Instance.PlaySFX(5);
    }

    public void PauseGame()
    {
        if (gamePaused)
        {
            Time.timeScale = 1;
            gamePaused = false;
        }
        else
        {
            Time.timeScale = 0;
            gamePaused = true;
        }
    }

    public void ExitGame() => Application. Quit();
    
    public void StartGame()
    {
        GameManager.Instance.canPlay = true;
        Cursor.visible = false;
    }

    public void RestartGame()
    {
        GameManager.Instance.isDead = false;
        SceneManager.LoadScene(0);
    }
}
