using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceToCenter : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.transform.SetPositionAndRotation(new Vector3(0f, 2f, 0f), new Quaternion());
    }
}
