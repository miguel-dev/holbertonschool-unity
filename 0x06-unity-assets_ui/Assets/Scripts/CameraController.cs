using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector3 offset_x;
    private Vector3 offset_y;
    private float turnSpeed = 3f;
    public bool isInverted = false;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0f, 1.5f, -7f);
        offset_x = new Vector3(0f, 1.5f, -7f);
        offset_y = new Vector3(0f, 0f, 1f);
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        if (Input.GetMouseButton(1))
        {
            offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;

            if (isInverted == true)
                offset = Quaternion.AngleAxis (-Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;
            else
                offset = Quaternion.AngleAxis (Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;

            transform.position = player.transform.position + offset;
            transform.LookAt(player.transform.position);
        }
    }
}
