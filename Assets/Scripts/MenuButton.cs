using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "ControllerLeft" || collision.collider.tag == "ControllerRight")
        {
            SceneManager.LoadScene(0);
        }

    }
}
