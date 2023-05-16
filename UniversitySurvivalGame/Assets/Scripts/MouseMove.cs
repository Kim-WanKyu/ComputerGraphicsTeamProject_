using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float sensivity = 500f;

    public float rotationX;
    public float rotationY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");

        float mouseMoveY = Input.GetAxis("Mouse Y");

        rotationY += mouseMoveX * sensivity * Time.deltaTime;

        rotationX += mouseMoveY * sensivity * Time.deltaTime;

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0);

        
    }
}
