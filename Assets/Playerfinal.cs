using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerfinal : MonoBehaviour
{
    public Playerfinal movement;
    public Score Score;
    private Rigidbody rb;

    public float speed = 5f;
    public float jumpforce = 5f;
    public float rotationSpeed = 8000.0f;

    private bool jumpkeypressed = true;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] Animator aniController;

    AudioSource jump1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerPrefs.SetString("CurrentScore", "0");
        jump1= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical") * (-1);

        if (jumpkeypressed && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.VelocityChange);
        }


        Vector3 movementDirection = new Vector3(verticalInput, 0, horizontalInput);
        movementDirection.Normalize();


        Vector3 newPosition = transform.position + movementDirection * speed * Time.deltaTime;
        rb.MovePosition(newPosition);

        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
        {
            aniController.SetBool("run", true);
        }
        else
        {
            aniController.SetBool("run", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            aniController.SetBool("jump", true);
        }
        else
        {
            aniController.SetBool("jump", false);
           
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump1.Play();
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

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            movement.enabled = false;
            rb.AddForce(Vector3.back * 4, ForceMode.Impulse);
            rb.AddForce(Vector3.up * 8 , ForceMode.Impulse);
            Invoke("GameOver", 1f);
        }
       
    }


        
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(verticalInput * speed, rb.velocity.y, horizontalInput * speed);

        if (rb.position.y < 3.37f)
        {
            movement.enabled = false;
            Invoke("GameOver", 1f);

            // This will call the function EndGame of GameManager script. 
            //FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void GameOver()
    {
        PlayerPrefs.SetString("CurrentScore", Score.ScoreText.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
