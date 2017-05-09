using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveButton : MonoBehaviour {

    public Transform bpmKnobTransform;
    private float bpmKnobTransformZ;

    private Renderer rend;
    private Material mat;
    public Color pink2, pink3;
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
                SteamVR_Controller.Input(3).TriggerHapticPulse(1000);
            }
            if (collision.collider.tag == "ControllerRight")
            {
                SteamVR_Controller.Input(4).TriggerHapticPulse(1000);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        bpmKnobTransformZ = bpmKnobTransform.position.z;

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
            Debug.Log("Saving to 'beat.txt'");

            //Try writing list of transforms to file
            try
            {

                ES2.Save(SaveLoad.transformList, "beat.txt?tag=shapeTransformList");
                ES2.Save(bpmKnobTransformZ, "beat.txt?tag=bpmTransformZ");
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            finally
            {
                Debug.Log("Beat saved.");
            }
        }
    }
}
