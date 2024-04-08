using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed = 20.0f;
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
    if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.A)||(Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.W))){
     aniController.SetBool("run",true);
    }
       else{
     aniController.SetBool("run",false);
    }
    if(Input.GetKey(KeyCode.Space)){
            speed = 30f;
            aniController.SetBool("jump",true);
    }
    else{
     aniController.SetBool("jump",false);
            speed = 20f;
    }
}
    
}

