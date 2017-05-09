using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListReporter : MonoBehaviour {

    Transform thisShapeTransform;

    private void Awake()
    {
        thisShapeTransform = GetComponent<Transform>();

    }
    private void Start()
    {
        SaveLoad.transformList.Add(thisShapeTransform);
    }
    private void LateUpdate()
    {
        Transform checkForChangeTransform = GetComponent<Transform>();
        if(thisShapeTransform != checkForChangeTransform)
        {
            SaveLoad.transformList.Remove(thisShapeTransform);
            SaveLoad.transformList.Add(checkForChangeTransform);
        }
    }
}
