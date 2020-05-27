using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform playerTransform;
    public float offsetCamera;

 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float playerZ = playerTransform.position.z;
        transform.position = new Vector3(transform.position.x, transform.position.y, playerTransform.transform.position.z + offsetCamera);
        
    }
}
