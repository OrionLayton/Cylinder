using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour {

    int leftIndex, rightIndex;
    private AudioSource source;
    public GameObject cylinder;
    private Rigidbody cylRB;

    //Get cylinder's transform
    private Transform cylTransform;

    // Make audio clip variable to repopulate
    public AudioClip audioClip;

    // Colors colors
    private Color pink1 = new Color32(255, 114, 252, 255);

    public float velToVol;
    private float hitVol;
    private void Awake()
    {
        cylRB = cylinder.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        hitVol = 0f;
        //velToVol = 0.05f;
        source = GetComponent<AudioSource>();
        audioClip = source.clip;

        source.velocityUpdateMode = AudioVelocityUpdateMode.Auto;
        //Find left and right controller indeces
        leftIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
        rightIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);

        
    }

    //NOTE: This works only when the other controller functions set the controllers to isTrigger when pressed
    //and are otherwise NOT triggers
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "ControllerLeft" || collision.collider.tag == "ControllerRight")
        {
            //Trigger haptics
            if (collision.collider.tag == "ControllerLeft")
            {
                SteamVR_Controller.Input(leftIndex).TriggerHapticPulse(1000);
            }
            if (collision.collider.tag == "ControllerRight")
            {
                SteamVR_Controller.Input(rightIndex).TriggerHapticPulse(1000);
            }

            
            //Set the hit volume relative to the velocity of the collision
            hitVol = collision.relativeVelocity.magnitude * velToVol;
            //Debug.Log("Magnitude of collision: " + collision.relativeVelocity.magnitude);
            //Debug.Log("Hit Volume: " + hitVol);

            // Max volume is 1 anyway, so we force that limit, and add a lower limit of 0.2f
            if(hitVol > 1f)
            {
                hitVol = 1f;
            }
            if (hitVol <= 0.1f)
            {
                hitVol = 0.2f;
            }

            // Play clip at hit volume
            source.PlayOneShot(source.clip, hitVol);
        }        

        if(collision.collider.tag == "Beat")
        {
           // Debug.Log("COLLISION DETECTED WITH" + collision.collider.name);
            // make the shape 'stick' to the wall
            cylRB.constraints = RigidbodyConstraints.FreezeAll;

            //cylRB.useGravity = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Beat")
        {
            // make the shape 'stick' to the wall
            cylRB.constraints = RigidbodyConstraints.FreezeAll;
            //cylRB.useGravity = false;

            Renderer rend = collision.collider.GetComponent<Renderer>();
            Material mat = rend.material;
            if (mat.GetColor("_Color") == pink1)
            {
                source.PlayOneShot(source.clip, 0.85f);
                source.mute = true;
            }
            else
            {
                source.mute = false;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // If the shape is no longer touching a Beat, it's free to move
        if (collision.collider.tag == "Beat")
        {
            cylRB.constraints = RigidbodyConstraints.None;
            //cylRB.useGravity = true;
        }

        // reset hit volume
        hitVol = 0f;
    }
}
