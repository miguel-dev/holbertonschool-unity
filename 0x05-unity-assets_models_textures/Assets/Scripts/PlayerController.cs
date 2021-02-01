using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private CharacterController control;
    public GameObject mainCamera;
    float moveHorizontal;
    float moveVertical;
    float speed;
    float jumpSpeed;
    float gravity;
    private Vector3 movement = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        control = GetComponent<CharacterController> ();
        speed = 7f;
        jumpSpeed = 7f;
        gravity = 21f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = transform.position - mainCamera.transform.position;
        relativePos.y = 0;
        relativePos.Normalize();

        if (control.isGrounded) {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");
            movement = moveHorizontal * mainCamera.transform.right + moveVertical * relativePos;
            movement.Normalize();
            if (movement != Vector3.zero)
            {
                transform.forward = movement;
            }
            movement *= speed;
            if (Input.GetButton("Jump"))
                movement.y = jumpSpeed;
        }
        movement.y -= gravity * Time.deltaTime;
        control.Move(movement * Time.deltaTime);
    }
}
