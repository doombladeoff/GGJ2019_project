using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour {

    public static int antivirusPoints = 0;

    Text textOfScore;

    void Start()
    {
        antivirusPoints = 0;
        textOfScore = GetComponent<Text>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            textOfScore.text = "ANTIVIRUS POINTS:" + antivirusPoints + "/20";
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            textOfScore.text = "ANTIVIRUS POINTS:" + antivirusPoints + "/50";
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            textOfScore.text = "ANTIVIRUS POINTS:" + antivirusPoints + "/25";
        }
    }
}
