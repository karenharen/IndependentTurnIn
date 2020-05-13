using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushPlayer : MonoBehaviour
{
    public float pushBack;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.back *pushBack, ForceMode.Impulse);

        Debug.Log(collision + " has entered");

    }

    
}
