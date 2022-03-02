using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Este : MonoBehaviour
{
    /*public void Destroy()
    {
        gameObject.SetActive(false);
    }*/

    private BoxCollider boxCollider;
    private SphereCollider sphereCollider;

    public bool isColliderUnActive = false;

    public void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.CompareTag("Player"))
        {

            this.sphereCollider.enabled = false;
            this.boxCollider.enabled = false;
            //gameObject.SetActive(false);
            
        }*/

        if (collision.gameObject.CompareTag("MapCback"))
        {
            gameObject.SetActive(false);
            isColliderUnActive = true;
        }
    }

    /*public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            this.sphereCollider.enabled = enabled;
            this.boxCollider.enabled = enabled;
            //gameObject.SetActive(false);

        }
    }*/
}