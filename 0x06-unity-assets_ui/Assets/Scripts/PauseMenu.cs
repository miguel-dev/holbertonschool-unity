using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
    }

    public void Resume()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
