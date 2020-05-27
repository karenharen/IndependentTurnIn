using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickerLight : MonoBehaviour
{
    public float flickerOn;
    public float flickerOff;
    Light light;

    // Start is called before the first frame update
    void Start()
    {
        light =  GetComponent<Light>();
        StartCoroutine(FlickerLight());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void repeatFLicker()
    {
        StartCoroutine(FlickerLight());
    }

    IEnumerator FlickerLight()
    {
        yield return new WaitForSeconds(flickerOn);
        light.enabled = false;
        yield return new WaitForSeconds(flickerOff);
        light.enabled = true;
        repeatFLicker();
    }
}
