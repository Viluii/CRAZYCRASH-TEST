using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float leftRightSpeed = 3.2f;

    private Rigidbody rb;

    private GameObject Player;
    private GameObject Kamera;
    private GameObject playerRotateL;
    private GameObject playerRotateR;
    private GameObject playerRotateF;
    ///private GameObject Este;
    ///private Este este;

    private float PmoveSpeed;

    public bool playerCollideWithOsb = false;

    public bool playerMoveLeft = false;
    public bool playerMoveRight = false;

    public bool playerGotL = false;

    public Vector3 stuckForce;

    private int osumat = 0;

    private float PlayerRotationY;

    void Start()
    {
        Player = GameObject.Find("Player");
        Kamera = GameObject.Find("Main Camera");
        playerRotateL = GameObject.Find("playerRotationL");
        playerRotateR = GameObject.Find("playerRotationR");
        playerRotateF = GameObject.Find("playerRotationF");
        rb = this.GetComponent<Rigidbody>();
        ///Este = GameObject.Find("Rock");
        ///este = Este.GetComponent<Este>();
    }

    void Update()
    {
        PmoveSpeed = moveSpeed;
        if (playerCollideWithOsb == true)
        {
            playerGotL = true;
            transform.Translate(PmoveSpeed * Time.deltaTime * Vector3.forward, Space.World);
            rb.AddForce(stuckForce, ForceMode.Impulse);
        }
        Move();
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

            if (Input.GetKey(KeyCode.A) && playerMoveRight == false || Input.GetKey(KeyCode.LeftArrow) && playerMoveRight == false)
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
            else if (Input.GetKey(KeyCode.D) && playerMoveLeft == false || Input.GetKey(KeyCode.RightArrow) && playerMoveLeft == false)
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
            osumat++;
            Debug.Log("Osuma");
            transform.Translate(0f * Time.deltaTime * Vector3.forward, Space.World);
        }
        if (osumat == 20)
        {
            gameObject.SetActive(false);
            Kamera.SetActive(false);
            playerCollideWithOsb = false;
        }

    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Este"))
        {
            playerCollideWithOsb = false;
            //Este.SetActive(false);
            //transform.Translate(PmoveSpeed * Time.deltaTime * Vector3.forward, Space.World);
        }
    }

    /*private void Rotate()
    {
        Player.transform.rotation = -20f;
    }*/
}