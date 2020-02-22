using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text spookyValueText;
    public int SpookyValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToSpookyValue()
    {
        SpookyValue+= 1;
        spookyValueText.text = SpookyValue.ToString();
    }
}
