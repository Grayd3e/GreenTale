using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject shopPanel;

    private GameData gameData;

    void Start()
    {

    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
    }

    public void Shop()
    {
        shopPanel.SetActive(true);
    }

    public void Wheel()
    {
        SceneManager.LoadScene("Wheel");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
