using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    float hAxis;
    float vAxis;
    public float speed;
    Vector3 moveVec;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxis("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed *Time.deltaTime;
    }
}
