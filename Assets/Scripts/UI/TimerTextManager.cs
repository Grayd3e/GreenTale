using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerTextManager : MonoBehaviour
{

    public TMP_Text freeSpinTimerText;
    public TMP_Text adSpinTimerText;

    private RealTimeCounter realTimer;

    void Start()
    {
        realTimer = FindObjectOfType<RealTimeCounter>();
    }
    
    void Update()
    {
        freeSpinTimerText.text = TimeSpan.FromSeconds(Mathf.Round(realTimer.freeSpinTimer)).ToString();
        adSpinTimerText.text = TimeSpan.FromSeconds(Mathf.Round(realTimer.adSpinTimer)).ToString();

        if(realTimer.isFreeTimerActive == false)
        {
            freeSpinTimerText.text = "";
        }

        if (realTimer.isAdTimerActive == false)
        {
            adSpinTimerText.text = "";
        }
    }
}
