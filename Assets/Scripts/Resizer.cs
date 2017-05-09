using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class Resizer : MonoBehaviour {

    
    public GameObject controllerLeft;
    public GameObject controllerRight;
    public GameObject cylinder;
    public GameObject floor;
    public Transform cylTransform;

    private Vector3 cylinderScale;
    private Vector3 controllerLeftPosition;
    private Vector3 controllerRightPosition;
    public Renderer rend;
    public Material mat;

    SteamVR_Controller.Device ctrlLeft;
    SteamVR_Controller.Device ctrlRight;
    SteamVR_TrackedObject ctL;
    SteamVR_TrackedObject ctR;

    int leftCtrlIndex, rightCtrlIndex, leftIndex, rightIndex;
    public float velToVol;

    private AudioSource source;

    // Make audio clip variable to repopulate
    //  public AudioClip audioClip;

    // Colors colors
    //private Color pink1 = new Color32(255, 113, 236, 255);
    //private Color red1 = new Color32(228, 108, 102, 255);
    //private Color clrSNR = new Color32(97, 216, 140, 255);
    //private Color clrOPHat = new Color32(196, 203, 60, 255);
    //private Color clrCLHat = new Color32(226, 211, 55, 255);
    //private Color clrRIDE = new Color32(216, 185, 53, 255);
    //private Color clrBASS = new Color32(62, 63, 140, 255);
    //private Color clrTUBE = new Color32(96, 97, 216, 255);
    public Color clrKCK;
    public Color clrSNR;
    public Color clrOPHat;
    public Color clrCLHat;
    public Color clrRIDE;
    public Color clrTOM;
    public Color clrBASS;
    public Color clrTUBE;

    private float hitVol;

    public AudioClip kck;
    public AudioClip snr;
    public AudioClip clhat;
    public AudioClip ophat;
    public AudioClip ride;
    public AudioClip tom;
    public AudioClip tube;
    public AudioClip bass;

    void Awake()
    {
        source = cylinder.GetComponent<AudioSource>();
        //audioClip = cylinder.GetComponent<AudioClip>();

        if(source.clip == null)
        {
            source.clip = kck;
        }
        //Connect tracked objects with game objects
        ctL = controllerLeft.GetComponent<SteamVR_TrackedObject>();
        ctR = controllerRight.GetComponent<SteamVR_TrackedObject>();

        //Get shape's Renderer and Material
        rend = cylinder.GetComponent<Renderer>();
        mat = rend.material;
    }

    private void Update()
    {


        //Get controller indeces
        leftCtrlIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.FarthestLeft);
        rightCtrlIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.FarthestRight);

        //Map controller inputs
        ctrlLeft = SteamVR_Controller.Input(leftCtrlIndex);
        ctrlRight = SteamVR_Controller.Input(rightCtrlIndex);
    }

    void FixedUpdate()
    {
        

        //Map position of controllers
        controllerLeftPosition = ctL.transform.position;
        controllerRightPosition = ctR.transform.position;

        //Get cylinder's pre-existing scale
        cylinderScale = cylTransform.localScale;

        ColorPitchClip(cylinderScale, mat);
    }

     void OnTriggerStay(Collider col)
    {
        //Check if the *staying* collider(s) is/are the controllers
        if (col.tag == "ControllerLeft" || col.tag == "ControllerRight")
        {
            //Check if the triggers are being held down
            if (ctrlLeft.GetPress(SteamVR_Controller.ButtonMask.Trigger) 
                && ctrlRight.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                // Pythagorean theorem for Euclidean Distance yo
                float x1, x2, y1, y2, z1, z2;
                x1 = controllerLeftPosition[0];
                x2 = controllerRightPosition[0];
                y1 = (controllerLeftPosition[1] + controllerRightPosition[1]) / 2.0f;
                y2 = floor.transform.position.y;
                z1 = controllerLeftPosition[2];
                z2 = controllerRightPosition[2];


                // If the cylinder is on its side, make Y the distance between controllers, and X/Z the height
                if (Mathf.Abs(cylTransform.rotation.eulerAngles.z) < 95 && 
                    Mathf.Abs(cylTransform.rotation.eulerAngles.z) > 85)
                {
                   // Debug.Log("IT'S ON ITS SIDE!");
                    // Make length aka Y equal to the distance between controllers
                    cylinderScale[1] = PythagTheorem(x1, x2, z1, z2);

                    // Make height the distance between the floor and average of the controllers' heights
                    // (using a value of 1 for X because any value will work)
                    cylinderScale[0] = (PythagTheorem(1, 1, y1, y2) / 2.0f);

                    // Make Z same as X so it's a circular-top cylinder
                    cylinderScale[2] = cylinderScale[0];
                }
                else
                {
                   // Debug.Log("IT'S ON ITS END!");
                    // Make width aka X equal to the distance between controllers
                    cylinderScale[0] = PythagTheorem(x1, x2, z1, z2);

                    // Make height the distance between the floor and average of the controllers' heights
                    // (using a value of 1 for X because any value will work)
                    cylinderScale[1] = (PythagTheorem(1, 1, y1, y2) / 2.0f);

                    // Make Z same as X so it's a circular-top cylinder
                    cylinderScale[2] = cylinderScale[0];
                }

                // Limit width to 1 at most 0.1 at least
                if(cylinderScale[0] > 1f)
                {
                    cylinderScale[0] = 1f;
                }
                if(cylinderScale[0] < 0.1f)
                {
                    cylinderScale[0] = 0.1f;
                }

                // Limit height to 0.8f at most 0.07 at least (bottom boundary of RIDE size)
                if (cylinderScale[1] > 0.8f)
                {
                    cylinderScale[1] = 0.8f;
                }
                if (cylinderScale[1] < 0.07f)
                {
                    cylinderScale[1] = 0.07f;
                }

                // Make Z same as X so it's a circular-top cylinder
                cylinderScale[2] = cylinderScale[0];

                //Set cylinder's new scale
                cylTransform.localScale = cylinderScale; 
            }
        }
    }

    // Pythagorean theorem for Euclidean Distance yo
    float PythagTheorem(float x1, float x2, float z1, float z2)
    {
        float distance;

        distance = Mathf.Sqrt(((x1 - x2) * (x1 - x2)) + ((z1 - z2) * (z1 - z2)));

        return distance;
    }

    // Change color, pitch, and audio clip based on shape size
    private void ColorPitchClip(Vector3 cylinderScale, Material material)
    {
        if (cylinderScale.x > 0.2f)
        {
            if (cylinderScale.y > 0.25f ) // tom
            {
                material.SetColor("_Color", clrTOM);
                material.SetColor("_Albedo", clrTOM);
                material.SetColor("_EmissionColor", clrTOM);
                source.pitch = 2f - (cylinderScale.x / 0.5f);
                source.clip = tom;
            }
            if (cylinderScale.y > 0.15f && cylinderScale.y < 0.25f)  // kick
            {
                material.SetColor("_Color", clrKCK);
                material.SetColor("_Albedo", clrKCK);
                material.SetColor("_EmissionColor", clrKCK);
                source.pitch = 2f - (cylinderScale.x / 0.7f);
                source.clip = kck;
            }
            if (cylinderScale.y < 0.15f && cylinderScale.y > 0.13f) // snare
            {
                material.SetColor("_Color", clrSNR);
                material.SetColor("_Albedo", clrSNR);
                material.SetColor("_EmissionColor", clrSNR);
                source.pitch = 2f - (cylinderScale.x / 0.5f);
                source.clip = snr;
            }
            if (cylinderScale.y < 0.13f && cylinderScale.y > 0.11f) // open hat
            {
                material.SetColor("_Color", clrOPHat);
                material.SetColor("_Albedo", clrOPHat);
                material.SetColor("_EmissionColor", clrOPHat);
                source.pitch = 2f - (cylinderScale.x / 0.5f);
                source.clip = ophat;
            }
            if (cylinderScale.y < 0.11f && cylinderScale.y > 0.09f) // closed hat
            {
                material.SetColor("_Color", clrCLHat);
                material.SetColor("_Albedo", clrCLHat);
                material.SetColor("_EmissionColor", clrCLHat);
                source.pitch = 2f - (cylinderScale.x / 0.5f);
                source.clip = clhat;
            }
            if (cylinderScale.y < 0.09f && cylinderScale.y > 0.07f) // ride
            {
                material.SetColor("_Color", clrRIDE);
                material.SetColor("_Albedo", clrRIDE);
                material.SetColor("_EmissionColor", clrRIDE);
                source.pitch = 2f - (cylinderScale.x / 0.5f);
                source.clip = ride;
            }
        }

        if (cylinderScale.x < 0.2f && cylinderScale.x > 0.15f) // bass
        {
            material.SetColor("_Color", clrBASS);
            material.SetColor("_Albedo", clrBASS);
            material.SetColor("_EmissionColor", clrBASS);
            source.pitch = 2f - (cylinderScale.y / 0.7f);
            source.clip = bass;
        }
        if (cylinderScale.x < 0.15f) // tube
        {
            material.SetColor("_Color", clrTUBE);
            material.SetColor("_Albedo", clrTUBE);
            material.SetColor("_EmissionColor", clrTUBE);
            source.pitch = 2f - (cylinderScale.y / 0.6f);
            source.clip = tube;
        }
    }

}
