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

    private bool isGameRunning = false;


    // Start is called before the first frame update
    void Start()
    {
        isGameRunning = true;
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

    public void AddToSpookyValue()
    {
        SpookyValue+= 1;
        spookyValueText.text = SpookyValue.ToString();
    }
}
