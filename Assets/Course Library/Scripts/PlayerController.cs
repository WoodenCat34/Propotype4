using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 20.0f;
    public Rigidbody playerRigidBody;
    public GameObject focalPoint;
    private float verticalInput; 
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody.GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint"); 
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical"); 
        playerRigidBody.AddForce(focalPoint.transform.forward * playerSpeed * verticalInput *  Time.deltaTime);
    }
}
