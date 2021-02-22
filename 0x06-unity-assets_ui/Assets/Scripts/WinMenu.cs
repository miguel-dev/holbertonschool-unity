using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentIndex == 4)
            SceneManager.LoadScene("MainMenu");
        else
            SceneManager.LoadScene(currentIndex + 1);
    }
}
