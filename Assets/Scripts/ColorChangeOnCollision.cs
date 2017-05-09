using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeOnCollision : MonoBehaviour {

    private Renderer rend;
    private Material mat;
    private Rigidbody rb;
    public Color pink2, pink3;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.tag == "ControllerLeft" || collision.collider.gameObject.tag == "ControllerRight")
        {
            rb.isKinematic = false;

            // Change color
            mat.SetColor("_Color", pink3);
            mat.SetColor("_Albedo", pink3);
            mat.SetColor("_EmissionColor", pink3);

            //Trigger haptics
            if (collision.collider.tag == "ControllerLeft")
            {
                SteamVR_Controller.Input(4).TriggerHapticPulse(1000);
            }
            if (collision.collider.tag == "ControllerRight")
            {
                SteamVR_Controller.Input(3).TriggerHapticPulse(1000);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.tag == "ControllerLeft" || collision.collider.gameObject.tag == "ControllerRight")
        {
            rb.isKinematic = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {


        if (collision.collider.gameObject.tag == "ControllerLeft" || collision.collider.gameObject.tag == "ControllerRight")
        {
            rb.isKinematic = true;

            mat.SetColor("_Color", pink2);
            mat.SetColor("_Albedo", pink2);
            mat.SetColor("_EmissionColor", pink2);

            //Trigger haptics
            if (collision.collider.tag == "ControllerLeft")
            {
                SteamVR_Controller.Input(3).TriggerHapticPulse(1000);
            }
            if (collision.collider.tag == "ControllerRight")
            {
                SteamVR_Controller.Input(4).TriggerHapticPulse(1000);
            }
        }
    }
}
