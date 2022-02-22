using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControll : MonoBehaviour
{
    [SerializeField]
    private Text ScoreNumText;
    private PlayerMovement playerMove;
    private GameObject Player;
    private int numBer;
    public bool IsThatStart = true;

    void Start()
    {
        Player = GameObject.Find("Player");
        playerMove = Player.GetComponent<PlayerMovement>();
        numBer = 000;
    }
    void Update()
    {
        IsplayerDead();
        if (playerMove.playerCollideWithOsb == false && playerMove.playerMoving == true)
        {
            IncreaseScore();
        }
        else
        {
            StartCoroutine(OdotaHetki());
        }
    }

    private void IncreaseScore()
    {
        if (IsThatStart == true)
        {
            numBer++;
        }
        numBer++;
        ScoreNumText.text = numBer.ToString();
    }

    IEnumerator OdotaHetki()
    {
        yield return new WaitForSeconds(20f);
    }

    private void IsplayerDead()
    {
        if (playerMove.isPlayerDead == true)
        {
            playerMove.playerCollideWithOsb = true;
        }
    }
}
