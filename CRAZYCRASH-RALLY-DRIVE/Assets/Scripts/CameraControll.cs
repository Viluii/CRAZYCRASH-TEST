using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private GameObject Kamera;
    private GameObject Player;

    private PlayerMovement playerMove;

    private float moveSpeed;
    private float leftRightSpeed;
    public Vector3 rePosition;

    // Start is called before the first frame update
    void Start()
    {
        Kamera = GameObject.Find("Main Camera");
        Player = GameObject.Find("Player");

        playerMove = Player.GetComponent<PlayerMovement>();

        moveSpeed = playerMove.moveSpeed;
        leftRightSpeed = playerMove.leftRightSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rePosition = Player.transform.position;
        Kamera.transform.position = new Vector3(rePosition.x, rePosition.y + 5.310003f, rePosition.z - 8.23f);
        moveSpeed = playerMove.moveSpeed;
        leftRightSpeed = playerMove.leftRightSpeed;
        /*if (playerMove.playerGotL == true)
        {
            
            //StartCoroutine(RePositionCamera());
        }*/
        if (playerMove.playerCollideWithOsb == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

            if (playerMove.playerMoveLeft == true)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
            if (playerMove.playerMoveRight == true)
            {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }
        }
        if (playerMove.playerCollideWithOsb == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 0f, Space.World);

            if (playerMove.playerMoveLeft == true)
            {
                transform.Translate(Vector3.left * Time.deltaTime * 0f);
            }
            if (playerMove.playerMoveRight == true)
            {
                transform.Translate(Vector3.right * Time.deltaTime * 0f);
            }
        }
        /*if (playerMove.playerCollideWithOsb == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 0f, Space.World);
        }*/
    }
    /*IEnumerator RePositionCamera()
    {
        Kamera.transform.position.Set(rePosition.x, rePosition.y, rePosition.z);
        yield return new WaitForSeconds(0.5f);
    }*/
}