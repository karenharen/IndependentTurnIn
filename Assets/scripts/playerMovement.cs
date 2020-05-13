using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float VertSpeed =20f;
    public float HorizSpeed =10f;
    public float RotationSpeed = 10f;
    public float JumpUp;
    public float gravityMultiplier;

    public Animator anim;
    bool isRunning = false;
    Rigidbody playerRB;

    public float boostSpeedAmount = 100.0f;
    public ParticleSystem boostParticles;

    public bool gameOver = false;
   public bool onGround = true;

    AudioSource audioSource;
    public AudioClip horseSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerRB = GetComponent<Rigidbody>();

  //     Physics.gravity *= gravityMultiplier;
        Debug.Log("This is start, Horse is " + transform.position);
    }

    private void Awake()
    {
        gameOver = false;
        onGround = true;
        isRunning = false;
        Debug.Log("This is awake, Horse is " + transform.position + " and gravity " + Physics.gravity);
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameOver) { 
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        var velocity = new Vector3(horizontalInput * HorizSpeed, 0f, verticalInput * VertSpeed) * Time.deltaTime;
        GetComponent<Rigidbody>().velocity = velocity;

        transform.Rotate(Vector3.up, Time.deltaTime * RotationSpeed * horizontalInput);
            anim.SetFloat("speed", verticalInput);
            
        }

       if (Input.GetKeyDown(KeyCode.Space) && !gameOver && onGround)
        {
            playerRB.AddForce(Vector3.up *JumpUp, ForceMode.Impulse);
            onGround = false;
        }
        


    }

    public void startSpookyBoost()
    {
        StartCoroutine(SpookyBoost());
    }

    IEnumerator SpookyBoost()
    {
        audioSource.PlayOneShot(horseSound);
        Debug.Log("coroutine is started");
        boostParticles.Play();
        float oldVertSpeed = VertSpeed;
        VertSpeed = VertSpeed += boostSpeedAmount;
        yield return new WaitForSeconds(5.0f);
        VertSpeed = oldVertSpeed;
        boostParticles.Stop();
    }

    public void setGameOverTrue()
    {
        gameOver = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
    }
}
