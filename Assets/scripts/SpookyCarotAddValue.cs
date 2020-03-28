using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookyCarotAddValue : MonoBehaviour
{
    public playerMovement playerScript;
    public GameObject carrot;

    //sorry about the bad naming of this it origonally added to a spooky meter but it made more sense for it to trigger the effects instead


    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerScript = player.GetComponent<playerMovement>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerScript.startSpookyBoost();
            Destroy(gameObject);
        }
    }
}
