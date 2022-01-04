using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Timer : MonoBehaviour
{
    bool stopwatchActive = false;
    float currentTime;
    public int startMinutes;
    public Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        // currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }
    public void StartTimer()
    {
        stopwatchActive = true;
    }
    public void StopTimer()
    {
        stopwatchActive = false;
    }
}
