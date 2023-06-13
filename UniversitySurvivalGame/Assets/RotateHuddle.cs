using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotateHuddle : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, speed, 0);
    }
}
