using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class PickupParent : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;
    GameObject clone;
    int cloneNumber = 0;
    Vector3 startPosition;

	void Awake () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
        trackedObj.gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
    }
    private void Update()
    {

        device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip) || device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            trackedObj.gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip) || device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            trackedObj.gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
        }
    }
    private void FixedUpdate()
    {
        startPosition = new Vector3(0f, 2.75f, 0f);

    }
    void OnTriggerStay(Collider col)
    {

        if (col.gameObject.tag != "shape") // if it's not a shape we don't want it
        {
            return;
        }

        if (device.GetPress(SteamVR_Controller.ButtonMask.Grip)) // Grip grabs a shape
        {
           // Debug.Log("GRABBING OBJECT");
            col.attachedRigidbody.isKinematic = true;
            col.gameObject.transform.SetParent(gameObject.transform);
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) // lifting Grip throws the shape
        {
           // Debug.Log("CALLING TOSS OBJECT");
            
            col.gameObject.transform.SetParent(null);
            col.attachedRigidbody.isKinematic = false;
            TossObject(col.attachedRigidbody);
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad)) // tapping Touchpad clones the shape
        {
            clone = Instantiate(col.gameObject, new Vector3(0f, 2.5f, 0f), Quaternion.identity);
            clone.transform.position = startPosition;
            Rigidbody cloneRB = clone.GetComponent<Rigidbody>();
            cloneRB.isKinematic = false;
            cloneNumber++;
            clone.name = col.gameObject.name + "_" + cloneNumber;
        }
    }
    void TossObject(Rigidbody rigidbody)
    {
       // Debug.Log("TOSSING OBJECT TOSSING OBJECT TOSSING OBJECT TOSSING OBJECT");
        Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
        if (origin != null)
        {
            rigidbody.velocity = origin.TransformVector(device.velocity);
            rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity);
        }
        else
        {
            rigidbody.velocity = device.velocity;
            rigidbody.angularVelocity = device.angularVelocity;
        }
    }

    void OnTriggerExit(Collider other)
    {
        other.gameObject.transform.SetParent(null);
        if (other.attachedRigidbody != null)
        {
            other.attachedRigidbody.isKinematic = false;
        }
    }
}
