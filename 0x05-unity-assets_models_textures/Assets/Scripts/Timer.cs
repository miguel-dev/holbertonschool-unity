using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private double timer;
    private double minutes;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        minutes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        double seconds = (int)(timer % 60);
        minutes = (int)(seconds / 60);
        double fractions = ((timer - seconds) * 100) % 100;
        TimerText.text = $"{minutes.ToString("0")}:{seconds.ToString("00")}.{fractions.ToString("00")}";
    }
}
