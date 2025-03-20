using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Coin : MonoBehaviour
{
    public bool isFromSpawner1; // Flag to track which spawner the coin came from
    public AudioSource src;
    public int coinvalue;

    // Coin PowerUp
    public Transform playerTransform;
    public float moveSpeed = 5f;

    CoinMoveOnPowerUp coinMoveScript;
    CoinMagnetPowerUp coinMagnetScript;
    Playerfinal playerScript;

    // Start is called before the first frame update
    void Start()
    {
        coinMoveScript = gameObject.GetComponent<CoinMoveOnPowerUp>();
        //coinMoveScript.enabled = false;
        playerScript = FindObjectOfType<Playerfinal>(); // Finds the Playerfinal script in the scene

        if (playerScript != null)
        {
            playerTransform = playerScript.gameObject.transform; // Assigns the player's transform
        }
        else
        {
            Debug.LogError("Playerfinal script not found in the scene!");
        }

        coinMagnetScript = FindObjectOfType<CoinMagnetPowerUp>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!coinMoveScript.enabled)
            {
                if (isFromSpawner1)
                {
                    CoinSpawnerManager.Instance.SpawnCoinFromSpawner2();
                }
                else
                {
                    CoinSpawnerManager.Instance.SpawnCoinFromSpawner1();
                }
            }
            if (src != null)
            {
                src.Play();
            }
            else
            {
                Debug.LogError("AudioSource missing on Coin!");
            }
            Destroy(gameObject);
            CoinCounter.Instance.IncreaseCoins(coinvalue);
        }
        if (other.gameObject.CompareTag("Coin Detector") && coinMagnetScript != null && coinMagnetScript.magnetOn)
        {
            //if (coinMoveScript != null)
            //{
            //    coinMoveScript.enabled = true;
            //}
            //else
            //{
            //    Debug.LogError("CoinMoveOnPowerUp script is missing on the coin!");
            //}
        }
    }
}
