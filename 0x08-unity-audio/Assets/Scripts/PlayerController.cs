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
    public GameObject Ty;
    private Animator animator;
    private float moveHorizontal;
    private float moveVertical;
    private float targetAngle;
    private float speed;
    private float jumpSpeed;
    private float gravity;
    private bool immobile = false;
    private Vector3 movement = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
        control = GetComponent<CharacterController> ();
        speed = 11f;
        jumpSpeed = 9f;
        gravity = 21f;
        animator = Ty.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = transform.position - mainCamera.transform.position;
        relativePos.Normalize();
        relativePos.y = 0;

        if (control.isGrounded) {
            animator.SetBool("isFalling", false);
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");
            movement = (moveHorizontal * mainCamera.transform.right) + (moveVertical * relativePos);
            movement.Normalize();

            if ((movement.x != 0 || movement.z != 0) && !immobile)
            {
                targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            }
            
            if (movement.x != 0 || movement.z != 0)
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isIdle", false);
            }
            else
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", true);
            }

            movement *= speed;
            if (Input.GetButton("Jump"))
            {
                movement.y = jumpSpeed;
                animator.SetTrigger("isJumping");
            }
        }
        else
        {
            if (transform.position.y < -1)
                animator.SetBool("isFalling", true);
        }
        movement.y -= gravity * Time.deltaTime;

        if (!immobile)
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

    public void DontMove()
    {
        immobile = true;
    }

    public void Move()
    {
        immobile = false;
    }
}
