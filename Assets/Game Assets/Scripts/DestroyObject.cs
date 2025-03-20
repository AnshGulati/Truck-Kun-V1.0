using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] List<GameObject> prefabsToSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(other.gameObject);

            //spawn
            int index = Random.Range(0, prefabsToSpawn.Count - 1);
            GameObject spawn = prefabsToSpawn[index];
            Quaternion desiredRotation = Quaternion.Euler(0f,90f,0f);
            Instantiate(spawn, spawnPoint.transform.position, desiredRotation);
        }
    }

}
