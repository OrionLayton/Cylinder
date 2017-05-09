using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour {

    private Renderer rend;
    private Material mat;

    public Color pink2, pink3;

    //private Color pink2 = new Color32(255, 0, 255, 255);
    //private Color pink3 = new Color32(255, 189, 209, 255);
    private void Awake()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "ControllerLeft" || collision.collider.gameObject.tag == "ControllerRight")
        {
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



    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "ControllerLeft" || collision.collider.gameObject.tag == "ControllerRight")
        {
            mat.SetColor("_Color", pink2);
            mat.SetColor("_Albedo", pink2);
            mat.SetColor("_EmissionColor", pink2);

            //Trigger haptics
            if (collision.collider.tag == "ControllerLeft")
            {
                SteamVR_Controller.Input(4).TriggerHapticPulse(1000);
            }
            if (collision.collider.tag == "ControllerRight")
            {
                SteamVR_Controller.Input(3).TriggerHapticPulse(1000);
            }

            Application.Quit();

        }
    }
}
