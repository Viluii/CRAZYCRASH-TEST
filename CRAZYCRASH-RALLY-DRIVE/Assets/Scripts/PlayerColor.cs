using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{

    private GameObject Player;
    private Material playerMaterial;
    public Renderer playerRenderer;
    public Color playerNormalColor;
    public Color playerNewColor;
    private PlayerMovement playerMove;

    private GameObject MainPlayer;
    private CarCollider carCollider;

    [SerializeField]
    private float Rn;
    [SerializeField]
    private float Gn;
    [SerializeField]
    private float Bn;
    [SerializeField]
    private float An;

    public bool IsThatNormalColor = true;
    public bool TrueOrFalse = false;
    public bool IsChangeEnded = false;

    //public float waitPlayer1 = 0f;
    //public float waitPlayer2 = 2f;

    [SerializeField]
    private float R;
    [SerializeField]
    private float G;
    [SerializeField]
    private float B;
    [SerializeField]
    private float A;

    float time = 0.5f;
    float timeDelay = 1.5f;


    void Start()
    {

        Player = GameObject.Find("Car");
        playerRenderer = Player.GetComponent<Renderer>();
        playerMaterial = Player.GetComponent<Material>();
        //playerMove = Player.GetComponent<PlayerMove>();

        MainPlayer = GameObject.Find("Player");
        carCollider = MainPlayer.GetComponent<CarCollider>();
    }

    void Update()
    {
        playerNormalColor = new Color(Rn, Gn, Bn, An);
        playerNewColor = new Color(R, G, B, A);

        /*if (playerMove.playerCollideWithOsb == true)
        {
            Change();
        }*/
        if (carCollider.playerCollide == true)
        {
            Change();
        }

        /*if (IsThatNormalColor == true)
        {
            playerRenderer.material.color = playerNormalColor;
        }
        if (IsThatNormalColor == false)
        {
            playerRenderer.material.color = playerNewColor;
        }*/


    }

    public void Change()
    {
        /*if (playerMove.playerCollideWithOsb == true)
        {*/
        for (int i = 0; i < 5; i++)
        {
            time += 1f * Time.deltaTime;

            if (time >= timeDelay)
            {
                time = 0.5f;
                IsThatNormalColor = TrueOrFalse;
            }

            if (IsThatNormalColor == false)
            {
                playerRenderer.material.color = playerNewColor;
                TrueOrFalse = true;
            }
            if (IsThatNormalColor == true)
            {
                playerRenderer.material.color = playerNormalColor;
                TrueOrFalse = false;
            }
        }

        //waitPlayer1 += 2f;
        return;
        //}
    }

    /*public void Blinking()
    {
            playerRenderer.material.color = playerNewColor;
            StartCoroutine(WaitForChangingColor());
            playerRenderer.material.color = playerNormalColor;
            StartCoroutine(WaitForChangingColor2());
    }

    IEnumerator WaitForChangingColor()
    {
        yield return new WaitForSeconds(5);
        yield return new WaitUntil(() => IsThatNormalColor == false);
    }

    IEnumerator WaitForChangingColor2()
    {
        yield return new WaitForSeconds(5);
        yield return new WaitUntil(() => IsThatNormalColor == true);
    }*/
}
