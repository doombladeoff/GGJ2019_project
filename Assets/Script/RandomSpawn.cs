using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpawn : MonoBehaviour
{
    public float SpeedSpawn = 1f;
    public Transform[] spawnPoints;
    public GameObject[] virus;
    public GameObject Player;
    int randomSpawnPoints, randomSpawnVirus;
    public static bool spawnAllowed;

    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            SpeedSpawn = 1f;
            spawnAllowed = true;
            InvokeRepeating("spawnVirus", 0f, SpeedSpawn);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            SpeedSpawn = 0.5f;
            spawnAllowed = true;
            InvokeRepeating("spawnVirus", 0f, SpeedSpawn);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            SpeedSpawn = 0.2f;
            spawnAllowed = true;
            InvokeRepeating("spawnVirus", 0f, SpeedSpawn);
        }
    }

    void spawnVirus()
    {
        if (spawnAllowed)
        {
            randomSpawnPoints = Random.Range(0, spawnPoints.Length);
            randomSpawnVirus = Random.Range(0, virus.Length);
            Instantiate(virus[randomSpawnVirus], spawnPoints[randomSpawnPoints].position, Quaternion.identity);
        }
    }
    

}
