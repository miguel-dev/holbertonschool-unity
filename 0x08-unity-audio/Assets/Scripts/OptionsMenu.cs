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
        
        SceneManager.LoadScene(sceneIndex);
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
