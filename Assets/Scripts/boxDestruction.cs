using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
     void OnCollisionEnter(Collision collision)
    {
        // Check if colliding with a box
        if (collision.gameObject.CompareTag("car"))
        {
            Vector3 forceDirection = collision.contacts[0].normal;
            GetComponent<Rigidbody>().AddForce(1,400,1);

        }
    }  
}
