using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private GameObject Player;
    private PlayerMovement playerMove;
    private GameObject Kamera;
    private GameObject StartMenuKamera;


    [HideInInspector]
    public bool IsGameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        //Kamera = GameObject.Find("Main Camera");
        //StartMenuKamera = GameObject.Find("StartMenuCamera");
        playerMove = Player.GetComponent<PlayerMovement>();
    }

    public void StartGame()
    {
        IsGameStarted = true;
        //Kamera.SetActive(true);
        //StartMenuKamera.SetActive(false);
    }
}
