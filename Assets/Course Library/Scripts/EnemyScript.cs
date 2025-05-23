using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float enemySpeed = 500.0f;
    private Rigidbody enemyRB;
    private GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 lookDirection = (player.transform.position - transform.position).normalized;
       enemyRB.AddForce(lookDirection * enemySpeed * Time.deltaTime);

        if (transform.position.y < -15) { 
        
            Destroy(gameObject);

        }
    }
}
