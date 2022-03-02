using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeControll : MonoBehaviour
{
    private Este esteS;
    private TrunkControll trunks;

    void Start()
    {
        esteS = gameObject.GetComponentInChildren<Este>();
        trunks = gameObject.GetComponentInChildren<TrunkControll>();
    }

    // Update is called once per frame
    void Update()
    {
        if (esteS.isColliderUnActive == true)
        {
            gameObject.SetActive(false);
            trunks.SetTrunkInActive();
        }
    }
}
