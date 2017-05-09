using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class LoadButton : MonoBehaviour {

    public GameObject cyl;
    private List<Transform> loadList;
    public Transform bpmKnob;
    private float bpmTransformLoadedZ;
    private Renderer rend;
    private Material mat;
    public Color pink2, pink3;

    private void Awake()
    {
        loadList = new List<Transform>();
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
                SteamVR_Controller.Input(4).TriggerHapticPulse(2000);
            }
            if (collision.collider.tag == "ControllerRight")
            {
                SteamVR_Controller.Input(3).TriggerHapticPulse(2000);
            }
            Debug.Log("Loading from 'beat.txt'");

            try
            {
                if (ES2.Exists("beat.txt?tag=bpmTransform"))
                {
                    bpmTransformLoadedZ = ES2.Load<float>("beat.txt?tag=bpmTransformZ");
                    Debug.Log("BPM TRANSFORM loaded.");
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            finally
            {
                Debug.Log("BPM transform loaded.");
            }

            //Try reading list of transforms from file
            try
            {
                if (ES2.Exists("beat.txt?tag=shapeTransformList"))
                {
                    loadList = ES2.LoadList<Transform>("beat.txt?tag=shapeTransformList");
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            finally
            {
                Debug.Log("Shape list loaded.");
            }

            // The BPM knob just needs to be put back where it was IN WORLD SPACE
            bpmKnob.SetPositionAndRotation(new Vector3(-1.701561f, 0.09164369f, bpmTransformLoadedZ), Quaternion.identity);

            // Go through and instantiate each shape in teh List, with its saved size & shape
            for (int i = 0; i < loadList.Count; i++)
            {
                Instantiate(cyl);
                cyl.name = loadList[i].name;
                cyl.transform.position = loadList[i].position;
                cyl.transform.rotation = loadList[i].rotation;
                cyl.transform.localScale = loadList[i].localScale;
            }

        }
    }
}
