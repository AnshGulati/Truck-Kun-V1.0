using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 100.0f;
    private Rigidbody rb;

    [SerializeField] Animator aniController;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
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
            Debug.Log("fghfh");

            aniController.SetBool("jump", true);

            StartCoroutine(delayAnimate());
        }
        
    }

    IEnumerator delayAnimate()
    {
        yield return new WaitForSeconds(1.5f);
        aniController.SetBool("jump", false);
    }
    /*    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer==8)
            {
                Debug.Log("hghg");
                aniController.SetBool("jump", false);
                aniController.SetBool("jump", true);
            }

        }*/
}

