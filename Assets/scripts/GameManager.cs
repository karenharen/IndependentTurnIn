using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text timerValueText;
    public float timerValue;
    public Text bestTimeTextValue;
    public float bestTimeValue;
    public Button restartButton;
    public Text lossText;

    public GameObject player;
    public Transform resetPlayerPosition;
    public GameObject enemy;
    public GameObject[] carrots;

    public ParticleSystem winParicles;
    public ParticleSystem playerSpookyParticles;

    public bool isGameRunning = false;
    private bool firsTimePlaying = false;


    // Start is called before the first frame update
    void Start()
    {
        isGameRunning = true;
        firsTimePlaying = true;
        restartButton.gameObject.SetActive(false);
        Instantiate(enemy);
        placeCarrots();

        bestTimeTextValue.text = PlayerPrefs.GetFloat("BestTime", 0).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning)
        {
            timerValue += Time.deltaTime;
            timerValueText.text = timerValue.ToString();
        }

    }

    void placeCarrots()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        foreach (GameObject carrot in carrots)
        {
            float randomZ = Random.Range(0f, 50f);
            float randomX = Random.Range(-11f, 1.5f);

            Instantiate(carrot, new Vector3(randomX, carrot.transform.position.y, randomZ), Quaternion.identity);

        }

    }



    public void PlayerCrossedFinishLine()
    {
        isGameRunning = false;
        winParicles.Play();
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
        winParicles.Stop();
        restartButton.gameObject.SetActive(false);
        timerValue = 0;
        isGameRunning = true;
        Instantiate(enemy);
        Instantiate(player);
 
        if (lossText.gameObject.activeSelf)
        {
            lossText.gameObject.SetActive(false);
        }
        
    }
}
