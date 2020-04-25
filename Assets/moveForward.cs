using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{
    public float speed = 10.0f;
    public float slowedSpeed = 5.0f;
    public ParticleSystem hitCyclist;

    private float endOfTheRoadZ = 135.0f;

    public AudioClip eakClip;
     AudioSource eak;

    private void Start()
    {
        eak = GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(slowDownEnemy());
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.z > endOfTheRoadZ)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator slowDownEnemy()
    {
        eak.PlayOneShot(eakClip);
        float oldSpeed = speed;
        speed = slowedSpeed; 
        hitCyclist.Play();
        yield return new WaitForSeconds(5.0f);
        speed = oldSpeed;
        hitCyclist.Stop();

    }
}
