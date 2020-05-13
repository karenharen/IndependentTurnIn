using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text timerValueText;
    public float timerValue;
    public Text bestTimeTextValue;
    public float bestTimeValue;
    public Button restartButton;
    public Text lossText;
    public Text winText;
    public pumpkinSpawner pumpkinSpawnScript;

    public GameObject player;
    public Transform resetPlayerPosition;
    public GameObject enemy;
    public GameObject[] carrots;

    public ParticleSystem winParicles;
    public ParticleSystem playerSpookyParticles;

    public bool isGameRunning = false;
    private bool firsTimePlaying = false;

    private playerMovement playerMovementScript;



    // Start is called before the first frame update
    void Start()
    {
        isGameRunning = true;
        firsTimePlaying = true;
        restartButton.gameObject.SetActive(false);
        Instantiate(enemy);
        placeCarrots();
        playerMovementScript = player.GetComponent<playerMovement>();

        bestTimeTextValue.text = PlayerPrefs.GetFloat("bestTimeValue").ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning)
        {
            timerValue += Time.deltaTime;
            timerValueText.text = timerValue.ToString();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            resetGame();
        }

    }

    void placeCarrots()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        foreach (GameObject carrot in carrots)
        {
            float randomZ = Random.Range(0f, 120f);
            float randomX = Random.Range(-11f, 1.5f);

            Instantiate(carrot, new Vector3(randomX, carrot.transform.position.y, randomZ), Quaternion.identity);

            Debug.Log(carrot +" is at x " + randomX +" and z is "+ randomZ);

        }

    }



    public void PlayerCrossedFinishLine()
    {
        isGameRunning = false;
        winParicles.Play();
        playerMovementScript.setGameOverTrue();
        pumpkinSpawnScript.setGameToOver();
        winText.enabled = true;

        if (firsTimePlaying == false)
        {
            if (timerValue < bestTimeValue)
            {
                bestTimeValue = timerValue;
                bestTimeTextValue.text = bestTimeValue.ToString();
                PlayerPrefs.SetFloat("BestTime",bestTimeValue);
            }
        } else
        {
            bestTimeValue = timerValue;
            bestTimeTextValue.text = bestTimeValue.ToString();
            
        }
        firsTimePlaying = false;
        restartButton.gameObject.SetActive(true);
    }

    public void EnemyWonTheRace()
    {
        lossText.gameObject.SetActive(true);
    }

    public void resetGame()
    {
        PlayerPrefs.SetFloat("bestTimeValue", bestTimeValue);
        SceneManager.LoadScene(0);

        /*
        winParicles.Stop();
        restartButton.gameObject.SetActive(false);
        timerValue = 0;
        isGameRunning = true;
        Instantiate(enemy);
        Instantiate(player);
 
        if (lossText.gameObject.activeSelf)
        {
            lossText.gameObject.SetActive(false);
        } */
        
    }
}
