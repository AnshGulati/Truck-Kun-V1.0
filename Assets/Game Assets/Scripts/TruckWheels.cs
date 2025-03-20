using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckWheels : MonoBehaviour
{
    public float rotationSpeed = 300f; // Speed of rotation

    void Update()
    {
        foreach (Transform wheel in transform)
        {
            wheel.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
    }
}