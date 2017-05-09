using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeTrigger : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        Collider col = collision.collider;
        if (col.tag == "shape")
        {

            col.attachedRigidbody.constraints = RigidbodyConstraints.None;

            Debug.Log(this.name + " DETECTS COLLISION DETECTED WITH " + col.tag + ", DETRIGGERING NOW");
            col.attachedRigidbody.isKinematic = false;
            if (col.transform.parent != null)
            {
                if (col.transform.parent.tag == "ControllerLeft" ||
               col.transform.parent.tag == "ControllerRight")
                {
                    if (col.GetComponentInParent<CapsuleCollider>().isTrigger == true)
                    {
                        col.GetComponentInParent<CapsuleCollider>().isTrigger = false;
                    }
                }
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Collider col = collision.collider;
        if (col.tag == "shape")
        {

            col.attachedRigidbody.constraints = RigidbodyConstraints.None;

            // Debug.Log("COLLISION STAYING DETECTED WITH " + col.tag);
            col.attachedRigidbody.isKinematic = false;
            if (col.transform.parent != null)
            {
                if (col.transform.parent.tag == "ControllerLeft" ||
               col.transform.parent.tag == "ControllerRight")
                {
                    if (col.GetComponentInParent<CapsuleCollider>().isTrigger == true)
                    {
                        col.GetComponentInParent<CapsuleCollider>().isTrigger = false;
                    }
                }
            }
        }
    }
}
