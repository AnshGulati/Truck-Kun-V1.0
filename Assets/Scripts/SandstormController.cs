using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandstormController : MonoBehaviour
{
    public float delayTime = 5f; // Delay time in seconds before the sandstorm starts
    public ParticleSystem sandstormParticle;

    private float timer = 0f;
    private bool hasStarted = false;

    void Update()
    {
        // Check if the delay time has passed and the sandstorm hasn't started yet
        if (!hasStarted && timer >= delayTime)
        {
            StartSandstorm();
        }

        else
        {
            timer += Time.deltaTime; // Increment timer
        }

    }

    void StartSandstorm()
    {
        sandstormParticle.Play(); // Start the sandstorm particle effect
        hasStarted = true; // Set flag to indicate the sandstorm has started
    }
}
