using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSequencer : MonoBehaviour {



    public GameObject beat_1;
    public GameObject beat_2;
    public GameObject beat_3;
    public GameObject beat_4;
    public GameObject beat_5;
    public GameObject beat_6;
    public GameObject beat_7;
    public GameObject beat_8;
    public GameObject beat_9;
    public GameObject beat_10;
    public GameObject beat_11;
    public GameObject beat_12;
    public GameObject beat_13;
    public GameObject beat_14;
    public GameObject beat_15;
    public GameObject beat_16;

    private Color pink1 = new Color32(255, 114, 252, 255);
    public Color purple1 = new Color32(194, 126, 255, 255);
    public Color purple2 = new Color32(175, 114, 229, 255);
    public Color purple3 = new Color32(145, 95, 191, 255);
    public Color purple4 = new Color32(97, 63, 127, 255);
    public Color purple5 = new Color32(48, 32, 64, 255);
    //public Color green1 = new Color32(30, 76, 47, 255);
    //public Color green2 = new Color32(91, 203, 132, 255);
    //public Color yellow1 = new Color32(196, 203, 60, 255);
    //public Color blue1 = new Color32(62, 63, 140, 255);
    //public Color red1 = new Color32(81, 204, 125, 255);

    public GameObject slider;

    public float tempo;

    private ArrayList beats = new ArrayList();

    private void Awake()
    {
        beats.Add(beat_1); beats.Add(beat_2); beats.Add(beat_3); beats.Add(beat_4);
        beats.Add(beat_5); beats.Add(beat_6); beats.Add(beat_7); beats.Add(beat_8);
        beats.Add(beat_9); beats.Add(beat_10); beats.Add(beat_11); beats.Add(beat_12);
        beats.Add(beat_13); beats.Add(beat_14); beats.Add(beat_15); beats.Add(beat_16);
    }
    private void Start()
    {
        StartCoroutine(TempoWait());
    }
    private void FixedUpdate()
    {
        tempo = GetTempo(slider);
    }
    IEnumerator TempoWait()
    {
        while (true)
        {
           // Debug.Log("Starting beat stepping>>>>>>>>>>");

            foreach (GameObject beat in beats)
            {
                //Transform trans = beat.GetComponent<Transform>();
                //trans.position += new Vector3(.025f, 0, .025f);
                Renderer rend = beat.GetComponent<Renderer>();
                Material mat = rend.material;
                mat.SetColor("_Color", pink1);
                mat.SetColor("_EmissionColor", pink1);

                yield return new WaitForSecondsRealtime(tempo);

                if(beat.gameObject == beat_1 || beat.gameObject == beat_5 || beat.gameObject == beat_9 || beat.gameObject == beat_13)
                {
                    mat.SetColor("_Color", purple5);
                    mat.SetColor("_EmissionColor", purple5);
                }
                if (beat.gameObject == beat_2 || beat.gameObject == beat_6 || beat.gameObject == beat_10 || beat.gameObject == beat_14)
                {
                    mat.SetColor("_Color", purple4);
                    mat.SetColor("_EmissionColor", purple4);
                }
                if (beat.gameObject == beat_3 || beat.gameObject == beat_7 || beat.gameObject == beat_11 || beat.gameObject == beat_15)
                {
                    mat.SetColor("_Color", purple3);
                    mat.SetColor("_EmissionColor", purple3);
                }
                if (beat.gameObject == beat_4 || beat.gameObject == beat_8 || beat.gameObject == beat_12 || beat.gameObject == beat_16)
                {
                    mat.SetColor("_Color", purple2);
                    mat.SetColor("_EmissionColor", purple2);
                }

                //trans.position += new Vector3(-.025f, 0, -.025f);
            } 
        }
        
    }

    private float GetTempo(GameObject slider)
    {
        float sliderTempo = 0;

        float sliderPositionZ = slider.transform.position.z + 0.4f;

        if(sliderPositionZ == 0)
        {
            sliderTempo = 9999;
        }
        else
        {
            sliderTempo = Mathf.Abs(1.4f - sliderPositionZ) / 8f;
        }
        

        return sliderTempo;
    }
}
