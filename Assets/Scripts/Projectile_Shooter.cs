using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float spawnInterval = 2f;
    public float spawnDistance = 10f;
    public float cubeSpeed = 5f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SpawnCube", 0f, spawnInterval);
    }

    private void SpawnCube()
    {
        Vector3 spawnPosition = player.position + Random.insideUnitSphere.normalized * spawnDistance;
        GameObject cube = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();
        if (cubeRigidbody != null)
        {
            Vector3 direction = (player.position - spawnPosition).normalized;
            cubeRigidbody.velocity = direction * cubeSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle collision with player here (e.g., damage player)
            Destroy(collision.gameObject);
            // Handle player destruction here (e.g., game over)
        }
        else
        {
            Destroy(collision.gameObject);
            // Destroy the cube if it collides with something other than the player
        }
    }
}
