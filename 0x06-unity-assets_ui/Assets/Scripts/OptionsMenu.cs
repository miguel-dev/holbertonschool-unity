using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void Back()
    {
        int sceneIndex = PlayerPrefs.GetInt("Scene");

        if (sceneIndex == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (sceneIndex == 1)
        {
            SceneManager.LoadScene("Level01");
        }
        else if (sceneIndex == 2)
        {
            SceneManager.LoadScene("Level02");
        }
        else if (sceneIndex == 3)
        {
            SceneManager.LoadScene("Level03");
        }
    }
}
