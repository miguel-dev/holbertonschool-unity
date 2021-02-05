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
        double seconds = Math.Round(timer, 2);
        if (seconds == 60.00)
        {
            timer = 0;
            minutes++;
        }
        string min = minutes.ToString();
        string sec = seconds.ToString(System.Globalization.CultureInfo.InvariantCulture);
        TimerText.text = $"{min}:{sec}";
    }
}
