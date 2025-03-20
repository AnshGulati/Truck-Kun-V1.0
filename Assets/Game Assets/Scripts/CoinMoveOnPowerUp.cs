using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMoveOnPowerUp : MonoBehaviour
{
    Coin coinScript;
    public AudioSource src;
    public int coinvalue;
    CoinMagnetPowerUp coinMagnetscript;

    private void Start()
    {
        coinScript = gameObject.GetComponent<Coin>();
        coinMagnetscript = FindObjectOfType<CoinMagnetPowerUp>();
    }

    private void Update()
    {
        //if (coinScript.playerTransform == null || !FindObjectOfType<CoinMagnetPowerUp>().magnetOn)
        //{
        //    enabled = false;
        //    return;
        //}
        if (coinMagnetscript.coinDetector.activeSelf)
        {
            transform.position = Vector3.MoveTowards(transform.position, coinScript.playerTransform.position, coinScript.moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player Bubble"))
        {
            if (src != null)
            {
                src.Play();
            }
            else
            {
                Debug.LogError("AudioSource missing on CoinMoveOnPowerUp!");
            }
            Destroy(gameObject);
            CoinCounter.Instance.IncreaseCoins(coinvalue);
        }
    }
}
