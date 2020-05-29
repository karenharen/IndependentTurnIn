using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFinishLine : MonoBehaviour
{

    public GameManager gm;
    AudioSource audioSource;
    public AudioClip winAudio;
    public AudioClip loseAudio;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audioSource.clip = winAudio;
            audioSource.Play();
            gm.PlayerCrossedFinishLine();

        }
        if (other.tag == "enemy")
        {
            Debug.Log(other + "crossed the finish line");

            if(gm.isGameRunning==true)
            {
                audioSource.clip = loseAudio;
                audioSource.Play();
                gm.EnemyWonTheRace();
            }
            
        } 
        
    }


}
