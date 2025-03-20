using UnityEngine;

public class TruckShake : MonoBehaviour
{
    public float shakeAmount = 0.1f;  // Intensity of shake
    public float shakeSpeed = 5f;     // Speed of shake

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float shakeOffset = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
        transform.position = startPosition + new Vector3(0, shakeOffset, 0);
    }
}
