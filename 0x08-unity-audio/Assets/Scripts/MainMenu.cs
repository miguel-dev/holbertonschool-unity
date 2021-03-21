using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("Scene", 0);
    }

    public void LevelSelect(int level)
    {
        if (level == 1)
        {
            SceneManager.LoadScene("Level01");
        }
        else if (level == 2)
        {
            SceneManager.LoadScene("Level02");
        }
        else if (level == 3)
        {
            SceneManager.LoadScene("Level03");
        }
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exited");
    }
}
