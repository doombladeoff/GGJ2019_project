using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour {

    public float timeLeft = 21.0f;
    public GameObject SkipText;


	void Update () {

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            SceneManager.LoadScene(1);
        }

        if (Input.anyKey)
            SkipText.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(1);

    }
}
