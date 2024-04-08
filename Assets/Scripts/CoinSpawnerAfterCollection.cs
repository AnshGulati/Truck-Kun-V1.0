using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerAfterCollection : MonoBehaviour
{
    public GameObject[] objects;
    public float Radius = 1f;
    public float delayAfterCollection = 2f;

    private void Start()
    {
        // Spawn the first coin immediately
        SpawnCoin();
    }

    public void SpawnCoin()
    {
        int randIndex = Random.Range(0, objects.Length);
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        randomPos = new Vector3(randomPos.x, 0, randomPos.y);
        Instantiate(objects[randIndex], this.transform.position + randomPos, Quaternion.identity);
    }

    public void OnCoinCollected()
    {
        StartCoroutine(SpawnCoinAfterDelay());
    }

    IEnumerator SpawnCoinAfterDelay()
    {
        yield return new WaitForSeconds(delayAfterCollection);
        SpawnCoin();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }
}