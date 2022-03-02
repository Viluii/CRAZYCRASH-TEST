using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelColliders : MonoBehaviour
{
    private CarController carController;
    private PlayerColor playerColor;
    private GameObject Player;
    private GameObject Kamera;
    private GameObject carBody;
    private CarCollider carCollider;

    public BoxCollider playersBoxCollider;
    public CapsuleCollider[] WheelCollider;
    public SphereCollider SphereCollider;

    private Vector3 playerPos_4z;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        carController = Player.GetComponent<CarController>();
        //carBody = GameObject.Find("Player");
        playerColor = Player.GetComponent<PlayerColor>();
        Kamera = GameObject.Find("Main Camera");
        carCollider = Player.GetComponent<CarCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Este") && carCollider.playerCollide == false)
        {
            carCollider.playerCollide = true;
            playersBoxCollider.enabled = false;
            WheelCollider[0].enabled = false;
            WheelCollider[1].enabled = false;
            WheelCollider[2].enabled = false;
            WheelCollider[3].enabled = false;
            SphereCollider.enabled = false;
            carCollider.osuma++;
            Debug.Log("Osuma");
            //StartCoroutine(PlayerColorBlink());
            //StartCoroutine(CollidersOff());
            //transform.Translate(lowSpeed * Time.deltaTime * Vector3.forward, Space.World);
            //StartCoroutine(CollidersOn());
            StartCoroutine(PlayerColliderOn());
        }
        if (carCollider.osuma == carCollider.maxOsumat)
        {
            carCollider.isPlayerDead = true;
            gameObject.SetActive(false);
            Kamera.SetActive(false);
            carCollider.playerCollide = false;
        }

        if (collider.gameObject.CompareTag("ToolBox") && carCollider.toolBoxPicked == false)
        {
            carCollider.toolBoxPicked = true;
            if (carCollider.isThatFullHealthReverse == true)
            {
                carCollider.osuma = 0;
            }
            else if (carCollider.isThatFullHealthReverse == false)
            {
                if (carCollider.osuma >= 2)
                {
                    carCollider.osuma -= 2;
                }
                else if (carCollider.osuma < 2)
                {
                    carCollider.osuma = 0;
                }
            }
            
        }
    }

    IEnumerator PlayerColliderOn()
    {
        playerPos_4z.z = Player.transform.position.z + 4.2f;
        //playerBoxCollider.enabled = true;
        //Debug.Log("Toimiiko?");
        yield return new WaitUntil(() => Player.transform.position.z >= playerPos_4z.z);
        carCollider.playerCollide = false;
        playersBoxCollider.enabled = true;
        WheelCollider[0].enabled = true;
        WheelCollider[1].enabled = true;
        WheelCollider[2].enabled = true;
        WheelCollider[3].enabled = true;
        SphereCollider.enabled = true;
        carCollider.isPlayerMoving = true;
        playerColor.playerRenderer.material.color = playerColor.playerNormalColor;
    }
}
