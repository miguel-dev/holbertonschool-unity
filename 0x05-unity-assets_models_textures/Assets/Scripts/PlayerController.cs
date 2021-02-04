using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController control;
    public GameObject mainCamera;
    private float moveHorizontal;
    private float moveVertical;
    private float speed;
    private float jumpSpeed;
    private float gravity;
    private Vector3 movement = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<CharacterController> ();
        speed = 7f;
        jumpSpeed = 9f;
        gravity = 21f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = transform.position - mainCamera.transform.position;
        relativePos.Normalize();
        relativePos.y = 0;

        if (control.isGrounded) {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");
            movement = (moveHorizontal * mainCamera.transform.right) + (moveVertical * relativePos);
            movement = transform.TransformDirection(movement);
            movement.Normalize();
            movement *= speed;
            if (Input.GetButton("Jump"))
                movement.y = jumpSpeed;
        }
        movement.y -= gravity * Time.deltaTime;
        control.Move(movement * Time.deltaTime);

        if (transform.position.y < -21)
        {
            transform.position = new Vector3(0f, 21f, 0f);
        }
    }
}
