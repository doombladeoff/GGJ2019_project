using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDefeat : MonoBehaviour {

    public GameObject LevelDefeatUI, Player;
    public float timeLeft = 1f;
    bool timers = false;
    bool sound = false;
    public AudioSource audios;

    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    void Update(float volume)
    {
        if (timers == true)
        {
            timeLeft -= Time.deltaTime;
        }

        if (timeLeft <= 0f)
        {
            LevelDefeatUI.SetActive(true);

            sound = !sound;
            if (sound)
            {
                audios.volume = 0f;
            }
            else
            {
                audios.volume = 0.5f;
            }

            Time.timeScale = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "virus")
        {
            timers = true;
            sound = true;
        }
    }

    public void ReloadLevel()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            Debug.Log("Перезагрузка уровня...");
            SceneManager.LoadScene(1);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            Debug.Log("Перезагрузка уровня...");
            SceneManager.LoadScene(2);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            Debug.Log("Перезагрузка уровня...");
            SceneManager.LoadScene(3);
        }
    }
}
