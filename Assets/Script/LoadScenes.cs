using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadScenes : MonoBehaviour {

    public GameObject pvpBtn;
    public GameObject pviaBtn;
    public GameObject onlineBtn;

    public GameObject pviaEasyBtn;
    public GameObject pviaMediumBtn;
    public GameObject pviaHardBtn;
    public GameObject backBtn;

    public void LaunchGame(Button button)
    {
        Application.LoadLevel(Int32.Parse(button.name));
    }


    public void CloseGame()
    {
        Application.Quit();
    }


    public void BackMenu()
    {
        Application.LoadLevel(0);
    }

    public void ShowDifferentLevel()
    {
        pvpBtn.SetActive(false);
        pviaBtn.SetActive(false);
        onlineBtn.SetActive(false);

        pviaEasyBtn.SetActive(true);
        pviaMediumBtn.SetActive(true);
        pviaHardBtn.SetActive(true);
        backBtn.SetActive(true);
    }

    public void HideDifferentLevel()
    {
        pvpBtn.SetActive(true);
        pviaBtn.SetActive(true);
        onlineBtn.SetActive(true);

        pviaEasyBtn.SetActive(false);
        pviaMediumBtn.SetActive(false);
        pviaHardBtn.SetActive(false);
        backBtn.SetActive(false);
    }
}
