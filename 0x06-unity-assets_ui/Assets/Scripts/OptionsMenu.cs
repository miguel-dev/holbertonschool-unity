using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Toggle InvertYToggle;

    void Start()
    {
        if (PlayerPrefs.GetString("isInverted") == "Yes")
            InvertYToggle.isOn = true;
    }

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

    public void Apply()
    {
        if (InvertYToggle.isOn)
            PlayerPrefs.SetString("isInverted", "Yes");
        else
            PlayerPrefs.SetString("isInverted", "No");

        Back();
    }
}
