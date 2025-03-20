using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnvironment : MonoBehaviour
{
    [SerializeField] private GameObject spawnPointEnv;
    [SerializeField] List<GameObject> prefabsToSpawnEnv;
    public float time = 2f;
    public float repeatrate = 5f;

    void Start()
    {
        InvokeRepeating("SpawnEnvironment", time, repeatrate);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Environment")
        {
            Destroy(other.gameObject);
        }
    }

    public void SpawnEnvironment()
    {
        int index = UnityEngine.Random.Range(0, prefabsToSpawnEnv.Count - 1);
        GameObject spawn = prefabsToSpawnEnv[index];
        Instantiate(spawn, spawnPointEnv.transform.position, Quaternion.identity);
    }

}
