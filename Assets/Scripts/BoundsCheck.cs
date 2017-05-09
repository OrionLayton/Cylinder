using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour {

    public Transform cylinder;
    public Rigidbody rb;
	
	// Update is called once per frame
	void FixedUpdate () {
        rb = GetComponent<Rigidbody>();

        // Bring it back if it's out of bounds
        //if (cylinder.position[1] < -20f || cylinder.position[0] > 20f || cylinder.position[0] < -20f ||
        //    cylinder.position[2] < -20f || cylinder.position[2] > 20f)
        if (cylinder.position[1] < -20f )
        {
            cylinder.position = new Vector3(0f, 0.5f, 0f);
        }

        // If it's too big or too small bring it back in bounds
        //if((Mathf.Abs(cylinder.localScale.x) + (Mathf.Abs(cylinder.localScale.z)) < 0.05f)){
        //    cylinder.localScale.Set(0.05f, 0.5f, 0.05f);
        //}
        //if (cylinder.localScale.y < 0.05f)
        //{
        //    cylinder.localScale.Set(0.05f, 0.05f, 0.05f);
        //}
        //if(cylinder.localScale.y > 0.5f)
        //{
        //    cylinder.localScale.Set(0, 0.5f, 0);
        //}

        // Set it upright
        cylinder.rotation = new Quaternion(0, 0, 0, 0);
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

}
