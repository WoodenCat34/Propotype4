using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 20.0f;
    public Rigidbody playerRigidBody;
    public GameObject focalPoint;
    private float verticalInput;
    public bool poweredUp; 
    private float powerUpStrength = 10.0f;
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
    private void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("PowerUp"))
        {
            StartCoroutine(PowerUpCountdownRoutine());
            poweredUp = true;
            Destroy(other.gameObject);
        }    
    }
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(5);

        poweredUp = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && poweredUp)
        {
            Debug.Log("Collided with Enemy" + collision.gameObject.name + "With PowerUp set to" + poweredUp);
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position-transform.position);
            enemyRB.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("Collided with Enemy" + collision.gameObject.name + "With PowerUp set to" + poweredUp);
        }
    }
}
