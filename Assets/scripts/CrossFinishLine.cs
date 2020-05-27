using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFinishLine : MonoBehaviour
{

    public GameManager gm;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gm.PlayerCrossedFinishLine();
        }
        if (other.tag == "enemy")
        {
            Debug.Log(other + "crossed the finish line");

            if(gm.isGameRunning==true)
            {
                gm.EnemyWonTheRace();
            }
            
        } 
        
    }
}
