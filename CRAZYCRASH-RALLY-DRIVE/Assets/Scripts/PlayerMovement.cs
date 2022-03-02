using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    // GameObjects
    private GameObject Player;
    private GameObject Kamera;
    private GameObject playerRotateL;
    private GameObject playerRotateR;
    private GameObject playerRotateF;
    private GameObject ScoreNumText;
    private GameObject startButtonB;
    //public GameObject[] Esteet;


    //Components & Scripts
    private Rigidbody rb;
    private ScoreControll scoreControll;
    private CapsuleCollider esteCollider;
    private BoxCollider playerBoxCollider;
    private PlayerColor playerColor;
    private StartButton startButtonS;
    /*private Material playerMaterial;
    private Renderer playerRenderer;
    private Color playerColor;*/


    // Float
    private float PmoveSpeed;
    public float moveSpeed;
    public float leftRightSpeed = 3.2f;
    private float lowSpeed;


    // Bool
    public bool playerCollideWithOsb = false;
    public bool playerMoveLeft = false;
    public bool playerMoveRight = false;
    [HideInInspector]
    public bool playerGotL = false;
    public bool isPlayerDead = false;
    public bool playerMoving = false;
    public bool IsTutorialEnded = false;
    public bool IsThatFirstStart = true;


    // Int
    [HideInInspector]
    public int osumat = 0;
    [HideInInspector]
    public int maxOsumat = 10;
    //private int esteidenMaara = 0;
    //private int i = 0;
    //private int ii = 0;
    //private int iii = 0;


    // Vector
    public Vector3 stuckForce;
    private Vector3 playerPos_4z;
    private Vector3 aloitusTienLoppu;


    void Start()
    {
        Player = GameObject.Find("Player");
        Kamera = GameObject.Find("Main Camera");
        playerRotateL = GameObject.Find("playerRotationL");
        playerRotateR = GameObject.Find("playerRotationR");
        playerRotateF = GameObject.Find("playerRotationF");

        startButtonB = GameObject.Find("StartButton");
        startButtonS = startButtonB.GetComponent<StartButton>();

        playerBoxCollider = Player.GetComponent<BoxCollider>();

        //playerMaterial = Player.GetComponent<Material>();

        //playerRenderer = Player.GetComponent<Renderer>();
        //Este = GameObject.FindGameObjectsWithTag("Este");

        /*var Este = GameObject.FindGameObjectsWithTag("Este");
        foreach (var colliders in Este)
        {
            colliders.GetComponent<CapsuleCollider>();
        }*/
        //Esteet = GameObject.FindGameObjectsWithTag("Este");

        rb = this.GetComponent<Rigidbody>();

        

        playerColor = Player.GetComponent<PlayerColor>();
        ///Este = GameObject.Find("Rock");
        ///este = Este.GetComponent<Este>();
        ///

        aloitusTienLoppu = new Vector3(0f, 0f, 17.5f);
    }

    void Update()
    {
        

        //Esteet = GameObject.FindGameObjectsWithTag("Este");
        //Debug.Log(Esteet.Length);

        /*while (i != Esteet.Length)
        {
            Esteet[i].AddComponent<CapsuleCollider>();
            //Debug.Log(Esteet.Length);
            i++;
        }*/

        /*esteidenMaara = Esteet.Length;
        esteCollider = Esteet[esteidenMaara].GetComponent<CapsuleCollider>();*/
        PmoveSpeed = moveSpeed;
        if (playerCollideWithOsb == true)
        {
            playerMoving = false;
            playerGotL = true;
            lowSpeed = PmoveSpeed - 2f;
            transform.Translate(lowSpeed * Time.deltaTime * Vector3.forward, Space.World);
            Vector3 targetPoint3 = (playerRotateF.transform.position);
            Player.transform.LookAt(targetPoint3);
            //rb.AddForce(stuckForce, ForceMode.Impulse);

        }

        if (startButtonS.IsGameStarted == true)
        {
            ScoreNumText = GameObject.Find("ScoreNumText");
            scoreControll = ScoreNumText.GetComponent<ScoreControll>();
            if (IsThatFirstStart == true)
            {
                StartCoroutine(TutorialTie());
            }
            Move();
        }
        //PlayerPosChecking();
    }

    private void Move()
    {
        if (playerCollideWithOsb == false)
        {
            //moveSpeed = 2.5f;
            Vector3 targetPoint3 = (playerRotateF.transform.position);
            Player.transform.LookAt(targetPoint3);
            transform.Translate(PmoveSpeed * Time.deltaTime * Vector3.forward, Space.World);
            //Player.transform.Rotate(0f, 0f, 0f);
            playerMoveLeft = false;
            playerMoveRight = false;

            if (Input.GetKey(KeyCode.A) && playerMoveRight == false && IsTutorialEnded == true || Input.GetKey(KeyCode.LeftArrow) && playerMoveRight == false && IsTutorialEnded == true)
            {

                Vector3 targetPoint = (playerRotateL.transform.position);
                transform.Translate(leftRightSpeed * Time.deltaTime * Vector3.left);
                Player.transform.LookAt(targetPoint);
                playerMoveLeft = true;
                //moveSpeed -= 0.2f;
                //Rotate();
                //Player.transform.Rotate(0f, -20f, 0f);
                /*for (int i = 0; i < 20; i++)
                {
                    Player.transform.Rotate(0f, -1f, 0f);
                }*/
                /*Player.transform.rotation.y = PlayerRotationY;
                if(PlayerRotationY => -20f){
                    Player.transform.rotation.y = -20f;
                }*/

            }
            else if (Input.GetKey(KeyCode.D) && playerMoveLeft == false && IsTutorialEnded == true || Input.GetKey(KeyCode.RightArrow) && playerMoveLeft == false && IsTutorialEnded == true)
            {

                Vector3 targetPoint2 = (playerRotateR.transform.position);
                transform.Translate(leftRightSpeed * Time.deltaTime * Vector3.right);
                Player.transform.LookAt(targetPoint2);
                playerMoveRight = true;
                //moveSpeed -= 0.2f;
                /*for (int i = 0; i < 20; i++)
                {
                    Player.transform.Rotate(0f, 1f, 0f);
                }*/
                //Player.transform.Rotate(0f, 20f, 0f);
            }
            playerMoving = true;
            playerGotL = false;
        }
    }
    /*public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Este"))
        {
            Debug.Log("Moro!");
        }
    }*/
    public void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Este"))
        {
            playerCollideWithOsb = true;
            playerBoxCollider.enabled = false;
            osumat++;
            Debug.Log("Osuma");
            //StartCoroutine(PlayerColorBlink());
            //StartCoroutine(CollidersOff());
            //transform.Translate(lowSpeed * Time.deltaTime * Vector3.forward, Space.World);
            //StartCoroutine(CollidersOn());
            StartCoroutine(PlayerColliderOn());
        }
        if (osumat == maxOsumat)
        {
            isPlayerDead = true;
            gameObject.SetActive(false);
            Kamera.SetActive(false);
            playerCollideWithOsb = false;
        }

    }
    /*public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Este"))
        {
            playerCollideWithOsb = false;
            //StartCoroutine(CollidersOff());
            //StartCoroutine(CollidersOn());
            //Este.SetActive(false);
            //transform.Translate(PmoveSpeed * Time.deltaTime * Vector3.forward, Space.World);
        }
    }*/

    /*private void Rotate()
    {
        Player.transform.rotation = -20f;
    }*/

    /*private void PlayerPosChecking()
    {
        if (Player.transform.position.z < 30f)
        {
            scoreControll.IsThatStart = true;
        }
        else
        {
            scoreControll.IsThatStart = false;
        }
    }*/

    /*IEnumerator PlayerColorBlink()
    {
        playerColor.TrueOrFalse = false;
        playerColor.Change();
        yield return new WaitUntil(() => playerColor.waitPlayer1 >= playerColor.waitPlayer2);
        playerColor.waitPlayer1 = 0f;
        playerColor.IsChangeEnded = false;
        /*playerColor.IsThatNormalColor = false;
        //playerColor.Blinking();
        yield return new WaitUntil(() => playerColor.playerRenderer.material.color == playerColor.playerNewColor);
        playerColor.IsThatNormalColor = true;
        //playerColor.Blinking();
        yield return new WaitUntil(() => playerColor.playerRenderer.material.color == playerColor.playerNormalColor);
        playerColor.IsThatNormalColor = false;
        //playerColor.Blinking();
        yield return new WaitUntil(() => playerColor.playerRenderer.material.color == playerColor.playerNewColor);
    }*/

    IEnumerator PlayerColliderOn()
    {
        playerPos_4z.z = Player.transform.position.z + 4.2f;
        //playerBoxCollider.enabled = true;
        //Debug.Log("Toimiiko?");
        yield return new WaitUntil(() => Player.transform.position.z >= playerPos_4z.z);
        playerCollideWithOsb = false;
        playerBoxCollider.enabled = true;
        playerColor.playerRenderer.material.color = playerColor.playerNormalColor;
    }

    /*IEnumerator CollidersOff()
    {
        while (ii != Esteet.Length)
        {
            Debug.Log("Toimiiko?");
            esteCollider = Esteet[ii].GetComponent<CapsuleCollider>();
            esteCollider.enabled = false;
            ii++;
        }
        ii = 0;
        yield return new WaitForSeconds(40);
    }
    IEnumerator CollidersOn()
    {
        
        while (iii != Esteet.Length)
        {
            Debug.Log("Ei toimi!");
            esteCollider = Esteet[iii].GetComponent<CapsuleCollider>();
            esteCollider.enabled = true;
            iii++;
        }
        iii = 0;
        playerCollideWithOsb = false;
        yield return new WaitForSeconds(20);
    }*/

    IEnumerator TutorialTie()
    {
        yield return new WaitUntil(() => Player.transform.position.z >= aloitusTienLoppu.z);
        IsTutorialEnded = true;
        IsThatFirstStart = false;
    }
}