using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool isFromSpawner1; // Flag to track which spawner the coin came from

    public int coinvalue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isFromSpawner1)
            {
                CoinSpawnerManager.Instance.SpawnCoinFromSpawner2();
            }
            else
            {
                CoinSpawnerManager.Instance.SpawnCoinFromSpawner1();
            }

            Destroy(gameObject);
            CoinCounter.Instance.IncreaseCoins(coinvalue);
        }
    }
}
