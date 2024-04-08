using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public PlayerMovement movement;
    public float speed = 5f;
    public float jumpforce = 7f;
    public Rigidbody rb;
    private bool jumpkeypressed = true;
    private float zMove;
    private float xMove;
    public Score Score;

    void Start()
    {
        PlayerPrefs.SetString("CurrentScore", "0");
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxis("Vertical") * (-1);
        zMove = Input.GetAxis("Horizontal");


        if (jumpkeypressed && Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Truck"))
        {
            jumpkeypressed = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Truck"))
        {
            jumpkeypressed = true;
        }

    }

    public void JumpPlayer()
    {
        rb.AddForce(Vector3.up * jumpforce, ForceMode.VelocityChange);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(xMove * speed, rb.velocity.y, zMove * speed);

        if (rb.position.y < 0.5f)
        {
            // This will call the function EndGame of GameManager script. 
            //FindObjectOfType<GameManager>().EndGame();
            movement.enabled = false;
            Invoke("GameOver", 1f);
        }
    }

    public void GameOver()
    {
        PlayerPrefs.SetString("CurrentScore", Score.ScoreText.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
