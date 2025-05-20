using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float rem;

    // Update is called once per frame
    void Update()
    {
        if(rem > 0)
        {
            rem -= Time.deltaTime;
        }
        else if(rem < 0)
        {
            rem = 0;
            timerText.color = Color.red;
        }

        int minutes = Mathf.FloorToInt(rem / 60);
        int seconds = Mathf.FloorToInt(rem % 60);
        
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
