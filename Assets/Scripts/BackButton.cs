using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackButton : MonoBehaviour {


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "ControllerLeft" || collision.collider.gameObject.tag == "ControllerRight")
        {
            SceneManager.LoadScene(1);
        }
    }
}
