using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject StartCamera;
    public GameObject GarageCamera;
    public GameObject MainMenu;
    public GameObject StartMenu;
    public GameObject GarageMenu;
    public GameObject scoreCanvas;

    public void Start()
    {
    }

    public void StartM()
    {
        MainMenu.SetActive(false);
        MainCamera.SetActive(false);
        StartCamera.SetActive(true);
        StartMenu.SetActive(true);
        GarageCamera.SetActive(false);
        GarageMenu.SetActive(false);
        scoreCanvas.SetActive(false);
    }
    public void MainM()
    {
        MainMenu.SetActive(true);
        MainCamera.SetActive(true);
        StartCamera.SetActive(false);
        StartMenu.SetActive(false);
        GarageCamera.SetActive(false);
        GarageMenu.SetActive(false);
    }
    public void Garage()
    {
        MainMenu.SetActive(false);
        MainCamera.SetActive(false);
        StartCamera.SetActive(false);
        StartMenu.SetActive(false);
        GarageCamera.SetActive(true);
        GarageMenu.SetActive(true);
        scoreCanvas.SetActive(false);
    }
    
    public void ScoreCanvas()
    {
        scoreCanvas.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    } 
}
