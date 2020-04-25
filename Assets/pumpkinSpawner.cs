using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpkinSpawner : MonoBehaviour
{
    public GameObject pumpkin;

    float time = 2.0f;
    float repeateRate = 2.0f;

    bool gameIsOver = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("pumpkinSpawning", time, repeateRate);
    }

    private void Update()
    {
    
    }

    void pumpkinSpawning()
    {
        if (!gameIsOver)
        {
            Instantiate(pumpkin, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }        
    }

    public void setGameToOver()
    {
        gameIsOver = true;
    }

    
}
