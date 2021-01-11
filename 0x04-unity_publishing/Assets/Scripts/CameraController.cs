using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 21, -7);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset; 
    }
}
