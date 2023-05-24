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
    bool wDown;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        
    }

    void Awake()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        wDown = Input.GetButton("Walk");
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) *Time.deltaTime;
        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
        transform.LookAt(transform.position +moveVec);
    }
}
