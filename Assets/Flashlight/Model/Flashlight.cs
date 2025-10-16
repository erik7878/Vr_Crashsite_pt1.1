using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light light;
    public bool isOn = false;

    // Start is called before the first frame update
    void Update()
    {
        GetComponent<Light>().enabled = isOn;
    }
    public void ToggleLight()
    {
        isOn = !isOn;
    }
}

