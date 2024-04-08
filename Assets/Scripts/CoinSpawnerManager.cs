using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerManager : MonoBehaviour
{
    public static CoinSpawnerManager Instance; // Singleton instance

    public GameObject[] objects; // Coin prefab to spawn
    public float Radius = 1f; //Gizmo Radius
    public Transform spawner1; // Reference to spawner-1
    public Transform spawner2; // Reference to spawner-2
    private int randIndex;

    public float time = 2f;
    public float repeatrate = 5f;


    private void Start()
    {
        InvokeRepeating("SpawnCoinFromSpawner1", time, repeatrate);
    }


    private void Awake()
    {
        // Create singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnCoinFromSpawner1()
    {
        randIndex = Random.Range(0, objects.Length);
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        randomPos = new Vector3(randomPos.x, 0, randomPos.y);
        Instantiate(objects[randIndex], spawner1.transform.position + randomPos, Quaternion.identity).GetComponent<Coin>().isFromSpawner1 = true;
    }

    public void SpawnCoinFromSpawner2()
    {
        randIndex = Random.Range(0, objects.Length);
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        randomPos = new Vector3(randomPos.x, 0, randomPos.y);
        Instantiate(objects[randIndex], spawner2.transform.position + randomPos, Quaternion.identity).GetComponent<Coin>().isFromSpawner1 = false;
    }
}
