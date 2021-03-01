using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player;
    public Canvas timerCanvas;

    void Finish()
    {
        mainCamera.gameObject.SetActive(true);
        player.GetComponent<PlayerController>().enabled = true;
        timerCanvas.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
