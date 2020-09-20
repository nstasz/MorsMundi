using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloPulse : MonoBehaviour
{
    public Light myLight;
    bool enlarging;


    private void Start()
    {
        enlarging = true;

    }
    void Update()
    {
        if (enlarging == true)
        {
            myLight.range = myLight.range + (Random.value / 20);
            GameObject.Find("Sun").transform.localScale += new Vector3 ((Random.value / 100), (Random.value / 100), (Random.value / 100));
        }
        else
        {
            myLight.range = myLight.range - (Random.value / 20);
            GameObject.Find("Sun").transform.localScale -= new Vector3((Random.value / 100), (Random.value / 100), (Random.value / 100));
        }

        if (myLight.range >= 19)
        {
            enlarging = false;
        }
        if (myLight.range <= 18)
        {
            enlarging = true;
        }
    }
}
