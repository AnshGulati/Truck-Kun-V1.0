using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWithAnimations : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 15.0f;
    public float rotationSpeed = 8000.0f;
    public float jumpForce = 5.0f;
    private float horizontalInput;
    private float verticalInput;

    [SerializeField] Animator aniController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical") * (-1);

        Vector3 movementDirection = new Vector3(verticalInput, 0, horizontalInput);
        movementDirection.Normalize(); 


        Vector3 newPosition = transform.position + movementDirection * speed * Time.deltaTime;
        rb.MovePosition(newPosition);

        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)))
        {
            aniController.SetBool("run", true);
        }
        else
        {
            aniController.SetBool("run", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            /* rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);*/
            aniController.SetBool("jump",true);

        }
        else
        {
            aniController.SetBool("jump", false);
        }
    }
/*    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Truck"))
        {
            Debug.Log("hghg");
            aniController.SetTrigger("jump2");
        }

    }*/

    private void FixedUpdate()
    {

        if (rb.position.y < 0.5f)
        {
            // This will call the function EndGame of GameManager script. 
            FindObjectOfType<GameManager>().EndGame();
        }
    }





















    /*public float speed = 5f;
    public float jumpforce = 7f;
    private bool jumpkeypressed = true;
    private float zMove;
    private float xMove;
    public float rotationSpeed = 100.0f;
    private Rigidbody rb;
    int animLayer = 1;
    [SerializeField] Animator aniController;

    void Start()
    { 
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        xMove = Input.GetAxis("Vertical") * (-1);
        zMove = Input.GetAxis("Horizontal");


        if (jumpkeypressed && Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.VelocityChange);
        }

        Vector3 movementDirection = new Vector3(zMove, 0, xMove);
        movementDirection.Normalize();


        Vector3 newPosition = transform.position + movementDirection * speed * Time.deltaTime;
        rb.MovePosition(newPosition);


        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)))
        {
            aniController.SetBool("run", true);
        }
        else
        {
            aniController.SetBool("run", false);
        }
        if (Input.GetKey(KeyCode.Space) || isPlaying(aniController,"jump"))
        {
            aniController.SetBool("jump", true);
        }
        else
        {
            aniController.SetBool("jump", false);

        }
    }

    private void FixedUpdate()
    {

        if (rb.position.y < 0.5f)
        {
            // This will call the function EndGame of GameManager script. 
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }*/

}
