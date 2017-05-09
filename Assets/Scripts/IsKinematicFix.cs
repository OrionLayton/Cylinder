using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsKinematicFix : MonoBehaviour
{
    //private Transform tr;
    private Rigidbody rb;
    private void Start()
    {

       // tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
       // tr.rotation = Quaternion.identity;
    }
    private void LateUpdate()
    {
        // rb.rotation = Quaternion.identity;
        if (!rb.isKinematic)
        {
            rb.isKinematic = true;
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "shape" || other.tag == "ControllerLeft" || other.tag == "ControllerRight")
    //    {
    //        Debug.Log("COLLISION DETECTED WITH " + other.tag);

    //        other.attachedRigidbody.isKinematic = false;
    //        other.transform.SetParent(null);
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}

    
}
