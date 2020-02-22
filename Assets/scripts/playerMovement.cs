using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float VertSpeed =20;
    public float HorizSpeed =10;
    public float RotationSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        //movement forward
        transform.Translate(Vector3.forward * Time.deltaTime * VertSpeed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * HorizSpeed * horizontalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * RotationSpeed * horizontalInput);
    }
}
