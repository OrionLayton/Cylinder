using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCollider : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "shape")
        {
            Rigidbody rb = collision.collider.attachedRigidbody;
           
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Debug.Log("COLLISION DETECTED BY BEAT, FREEZING COLLIDER");
        }
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "shape")
        {
            Rigidbody rb = collision.collider.attachedRigidbody;

            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "shape")
        {
            Rigidbody rb = collision.collider.attachedRigidbody;

            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
