using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player;
    public float turnSpeed = 1;

    public Vector3 offset = new Vector3(-8f,5f,.6f);
    public float rotationOffset;
    public float PlayerPreviousRotY = 6;
  
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
           transform.position = player.transform.position + offset;
           Vector3 currentPlayerLocation = player.transform.position;
           float horizontalInput = Input.GetAxis("Horizontal");

        /*   

              float currentPlayerRotation = player.transform.eulerAngles.y * horizontalInput;
              float cameraRotation = (currentPlayerRotation - PlayerPreviousRotY) * Time.deltaTime;
              Debug.Log(cameraRotation);


              transform.RotateAround(currentPlayerLocation, Vector3.up, 20 *Time.deltaTime);
              PlayerPreviousRotY = player.transform.eulerAngles.y;
              Debug.Log("Player Previous" + PlayerPreviousRotY);
              Debug.Log("player current rotation " + currentPlayerRotation); 
   */

        offset = Quaternion.AngleAxis(horizontalInput, Vector3.up) * offset;
        transform.position = player.transform.position + offset;

       transform.LookAt(currentPlayerLocation);
    }
}
