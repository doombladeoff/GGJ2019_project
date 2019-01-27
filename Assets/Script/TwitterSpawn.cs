using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitterSpawn : MonoBehaviour {

    public float SpeedSpawn = 10f;
    public Transform[] spawnPoints;
    public GameObject[] virus;
    public GameObject Player;
    int randomSpawnPoints, randomSpawnVirus;
    public static bool spawnAllowed;

    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("spawnVirus", 0f, SpeedSpawn);
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
