﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController control;
    public GameObject mainCamera;
    public Text TimerText;
    public Canvas pauseCanvas;
    private float moveHorizontal;
    private float moveVertical;
    private float speed;
    private float jumpSpeed;
    private float gravity;
    private Vector3 movement = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
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
        
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1)
                pauseCanvas.GetComponent<PauseMenu>().Pause();
            else
                pauseCanvas.GetComponent<PauseMenu>().Resume();
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y < -21)
        {
            transform.position = new Vector3(0f, 30f, 0f);
            movement = Vector3.zero;
            GetComponent<Timer>().enabled = false;
            TimerText.text = "0:00.00";
            TimerText.color = Color.white;
            TimerText.fontSize = 48;
        }
    }
}
