using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text time;
    public Canvas WinCanvas;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Timer>().enabled = false;
            time.enabled = false;
            WinCanvas.gameObject.SetActive(true);
            other.gameObject.GetComponent<Timer>().Win();
        }
    }
}
