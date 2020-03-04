using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text spookyValueText;
    public int SpookyValue = 0;
    public Text timerValueText;
    public float timerValue;
    public Text bestTimeTextValue;
    public float bestTimeValue;
    public Button restartButton;

    public Transform player;
    public Transform resetPlayerPosition;

    public ParticleSystem winParicles;
    public ParticleSystem playerSpookyParticles;

    private bool isGameRunning = false;
    private bool firsTimePlaying = false;


    // Start is called before the first frame update
    void Start()
    {
        isGameRunning = true;
        firsTimePlaying = true;
        restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning)
        {
            timerValue += Time.deltaTime;
            timerValueText.text = timerValue.ToString();
        }

        if (SpookyValue >= 2)
        {
            Debug.Log("spooky");
            playerSpookyParticles.Play();
        }
    }

    public void AddToSpookyValue()
    {
        SpookyValue++;
        spookyValueText.text = SpookyValue.ToString();
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
            }
        } else
        {
            bestTimeValue = timerValue;
            bestTimeTextValue.text = bestTimeValue.ToString();
            
        }
        firsTimePlaying = false;
        restartButton.gameObject.SetActive(true);
    }

    public void resetGame()
    {
        winParicles.Stop();
        playerSpookyParticles.Stop();
        restartButton.gameObject.SetActive(false);
        player.position = resetPlayerPosition.position;
        timerValue = 0;
        SpookyValue = 0;
        isGameRunning = true;

    }
}
