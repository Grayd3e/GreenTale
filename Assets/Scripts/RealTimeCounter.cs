using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTimeCounter : MonoBehaviour
{
    public static RealTimeCounter realTimeCounter;
    public float freeSpinTimer;
    public float adSpinTimer;    

    public bool isFreeTimerActive;
    public bool isAdTimerActive;

    private float twelveHoursTimer = 43200;
    private GameData gameData;

    public void Awake()
    {
        if (realTimeCounter == null)
        {
            DontDestroyOnLoad(this.gameObject);
            realTimeCounter = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        gameData = FindObjectOfType<GameData>();

        Load();
    }

    public void Load()
    {        
        TimeSpan timeNow = DateTime.Now.TimeOfDay;
        TimeSpan timeLeft = timeNow - gameData.saveData.timeOld;

        Debug.Log("Time past " + timeLeft);
        
        adSpinTimer = gameData.saveData.adsSpinTimer - (float)(timeLeft.Seconds);

        if (gameData.saveData.isFreeSpinTimerActive)
        {
            isFreeTimerActive = true;
            freeSpinTimer = gameData.saveData.freeSpinTimer - (float)(timeLeft.Seconds);
        }
        else
        {            
            ResetFreeTimer();
        }

        if (gameData.saveData.isAdsSpinTimerActive)
        {
            isAdTimerActive = true;
            adSpinTimer = gameData.saveData.adsSpinTimer - (float)(timeLeft.Seconds);
        }
        else
        {
            ResetAdTimer();
        }
    }

    private void Update()
    {
        TimeSpan currFreeTimer = TimeSpan.FromSeconds(Mathf.Round(freeSpinTimer));
        TimeSpan currAdTimer = TimeSpan.FromSeconds(Mathf.Round(adSpinTimer));

        if (isFreeTimerActive)
        {
            if (freeSpinTimer > 0)
            {
                freeSpinTimer -= Time.deltaTime;
            }
            else if (freeSpinTimer <= 0)
            {
                ResetFreeTimer();
            }
        }

        if (isAdTimerActive)
        {
            if (adSpinTimer > 0)
            {
                adSpinTimer -= Time.deltaTime;
            }
            else if (adSpinTimer <= 0)
            {
                ResetAdTimer();
            }
        }
    }

    public void SaveDate()
    {
        gameData.saveData.isFreeSpinTimerActive = isFreeTimerActive;
        gameData.saveData.isAdsSpinTimerActive = isAdTimerActive;

        gameData.saveData.freeSpinTimer = freeSpinTimer;
        gameData.saveData.adsSpinTimer = adSpinTimer;

        gameData.saveData.timeOld = DateTime.Now.TimeOfDay;
    }

    public void ActivateFreeSpinTimer()
    {
        isFreeTimerActive = true;
    }
    public void ActivateAdSpinTimer()
    {
        isAdTimerActive = true;
    }    

    public void ResetFreeTimer()
    {
        isFreeTimerActive = false;
        freeSpinTimer = twelveHoursTimer;
    }

    public void ResetAdTimer()
    {
        isAdTimerActive = false;
        adSpinTimer = twelveHoursTimer;
    }

    private void OnApplicationQuit()
    {
        SaveDate();
    }
}
