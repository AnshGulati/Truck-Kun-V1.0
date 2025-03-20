using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnetPowerUp : MonoBehaviour
{
    public GameObject coinDetector;
    public float waitTime = 10f;
    public GameObject coinPowerUpEffect;
    public bool magnetOn = false;

    private void Start()
    {
        coinDetector = GameObject.FindGameObjectWithTag("Coin Detector");
        coinPowerUpEffect = GameObject.FindGameObjectWithTag("Coin PowerUp Effect");
        if (coinDetector != null) coinDetector.SetActive(false);
        if (coinPowerUpEffect != null) coinPowerUpEffect.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ActivateCoin());
            Destroy(transform.GetChild(0).gameObject);
        }
    }

    IEnumerator ActivateCoin()
    {
        if (coinPowerUpEffect != null) coinPowerUpEffect.SetActive(true);
        if (coinDetector != null) coinDetector.SetActive(true);
        magnetOn = true;

        yield return new WaitForSeconds(waitTime);

        magnetOn = false;
        if (coinDetector != null) coinDetector.SetActive(false);
        if (coinPowerUpEffect != null) coinPowerUpEffect.SetActive(false);
    }
}