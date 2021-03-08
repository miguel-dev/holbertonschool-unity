using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyController : MonoBehaviour
{
    public GameObject player;
    private PlayerController script;

    void Start()
    {
        script = player.GetComponent<PlayerController>();
    }
    public void DontMove()
    {
        script.DontMove();
    }

    public void Move()
    {
        script.Move();
    }
}
