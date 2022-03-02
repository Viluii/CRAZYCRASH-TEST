using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControll : MonoBehaviour
{
    private GameObject Player;

    private GameObject fCollider;
    private GameObject bCollider;

    private BoxCollider fBoxCollider;
    private BoxCollider bBoxCollider;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        fCollider = GameObject.Find("FrontCollider");
        bCollider = GameObject.Find("BackCollider");

        fBoxCollider = fCollider.GetComponent<BoxCollider>();
        bBoxCollider = bCollider.GetComponent<BoxCollider>();

        bCollider.transform.parent = null;
        fCollider.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        bCollider.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1f, Player.transform.position.z - 8.07f);
    }

    /*public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Este"))
        {
            gameObject.SetActive(false);
        }
    }*/
}
