﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float VertSpeed =20;
    public float HorizSpeed =10;
    public float RotationSpeed = 10;


    public float boostSpeedAmount = 100.0f;
    public ParticleSystem boostParticles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        var velocity = new Vector3(horizontalInput * HorizSpeed, 0f, verticalInput * VertSpeed) * Time.deltaTime;
        GetComponent<Rigidbody>().velocity = velocity;

        transform.Rotate(Vector3.up, Time.deltaTime * RotationSpeed * horizontalInput);


    }

    public void startSpookyBoost()
    {
        StartCoroutine(SpookyBoost());
    }

    IEnumerator SpookyBoost()
    {
        Debug.Log("coroutine is started");
        boostParticles.Play();
        float oldVertSpeed = VertSpeed;
        VertSpeed = VertSpeed += boostSpeedAmount;
        yield return new WaitForSeconds(5.0f);
        VertSpeed = oldVertSpeed;
        boostParticles.Stop();
    }
}
