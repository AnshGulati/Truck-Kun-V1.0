using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour
{
    [SerializeField] private float envSpeed;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * envSpeed);
    }

}
