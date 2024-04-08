using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] objects;
    public float Radius = 1f;
    public float time = 2f;
    public float repeatrate = 5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjectAtRandomTwo", time, repeatrate);
    }

    public void SpawnObjectAtRandomTwo()
    {
        int randIndex = Random.Range(0, objects.Length);
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        randomPos = new Vector3(randomPos.x, 0, randomPos.y);
        Instantiate(objects[randIndex], this.transform.position + randomPos, Quaternion.identity);
    }

    private void OnDrawGizmosTwo()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }

}
