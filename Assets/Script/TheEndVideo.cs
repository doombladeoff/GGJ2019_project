using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEndVideo : MonoBehaviour {

    public float timeLeft = 19.0f;

    void Update()
    {

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Time.timeScale = 0f;
        }

    }
}
