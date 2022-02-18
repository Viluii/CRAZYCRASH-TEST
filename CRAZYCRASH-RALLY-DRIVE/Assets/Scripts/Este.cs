using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Este : MonoBehaviour
{
    /*public void Destroy()
    {
        gameObject.SetActive(false);
    }*/

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            gameObject.SetActive(false);
            
        }
    }
}