using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour {

    public static List<Transform> transformList;

    private void Awake()
    {
        transformList = new List<Transform>();
    }

}
