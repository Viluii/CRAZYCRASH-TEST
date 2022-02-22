using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoints : MonoBehaviour
{
    private GameObject playerRotateL;
    private GameObject playerRotateR;
    private GameObject playerRotateF;
    private GameObject Player;

    private PlayerMovement playerMove;

    private float moveSpeed;
    private float leftRightSpeed;
    public Vector3 rePositionF;
    public Vector3 rePositionL;
    public Vector3 rePositionR;

    //public Vector3 lastV3;

    /*public Transform TestRotateL1, TestRotateL2;
    private Vector3 nextPos;
    private float Speed;*/
    // Start is called before the first frame update
    void Start()
    {
        playerRotateL = GameObject.Find("playerRotationL");
        playerRotateR = GameObject.Find("playerRotationR");
        playerRotateF = GameObject.Find("playerRotationF");
        Player = GameObject.Find("Player");

        playerMove = Player.GetComponent<PlayerMovement>();

        moveSpeed = playerMove.moveSpeed;
        leftRightSpeed = playerMove.leftRightSpeed;
        //Speed = 7.2f;
    }

    // Update is called once per frame
    void Update()
    {
        rePositionF = Player.transform.position;
        rePositionL = Player.transform.position;
        rePositionR = Player.transform.position;
        playerRotateF.transform.position = new Vector3(rePositionF.x, rePositionF.y + 1.1f, rePositionF.z + 50f);
        playerRotateL.transform.position = new Vector3(rePositionL.x - 30f, rePositionL.y + 1.1f, rePositionR.z + 50f);
        playerRotateR.transform.position = new Vector3(rePositionR.x + 30f, rePositionR.y + 1.1f, rePositionR.z + 50f);
        //TestRotateL1.position = new Vector3(rePositionL.x - 30f, rePositionL.y + 1.1f, rePositionR.z + 50f);
        //TestRotateL2.position = new Vector3(0f, 0f, 0f);
        //TestRotateL2.position = new Vector3(playerRotateL.transform.position.x - 30f, playerRotateL.transform.position.y, playerRotateL.transform.position.z);
        moveSpeed = playerMove.moveSpeed;
        leftRightSpeed = playerMove.leftRightSpeed;

        //playerRotateL.transform.position = TestRotateL1.position;
        //lastV3 = new Vector3(TestRotateL2.position.x, rePositionL.y + 1.1f, rePositionR.z + 50f);

        if (playerMove.playerCollideWithOsb == false)
        {

            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            //playerRotateF.transform.RotateAround(Player.transform.position, Vector3.left, (Speed * Time.deltaTime) * 20);
            if (playerMove.playerMoveLeft == true)
            {
                //playerRotateL.transform.position = new Vector3(lastV3.x, lastV3.y, lastV3.z);
                //playerRotateL.transform.position = Vector3.MoveTowards(playerRotateL.transform.position, TestRotateL2.transform.position, Speed * Time.deltaTime);

                //playerRotateF.transform.RotateAround(Player.transform.position, Vector3.down, (Speed * Time.deltaTime) * 20);
                //transform.Translate(Vector3.left * Time.deltaTime * Speed);
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
    }
}