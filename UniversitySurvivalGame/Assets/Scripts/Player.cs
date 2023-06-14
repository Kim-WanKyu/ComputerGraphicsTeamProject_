using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float hAxis;
    private float vAxis;
    private int health;
    public float speed; //?

    private bool wDown;
    private bool jDown;
    private bool isJump;
    private bool isDamage;

    private Vector3 moveVec;

    private Animator anim;
    private Rigidbody rigid;
    private MeshRenderer[] meshs;

    [SerializeField]
    private GameObject startPositionObject;

    private bool isEnterWall;

    // Start is called before the first frame update
    void Start()
    {
        speed = 15;
        health = 100;
        isEnterWall = false;

        rigid.position = startPositionObject.transform.position;
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        meshs = GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
    }

    private void FixedUpdate()
    {
        FreezeRotation();
        StopToWall();
    }
    public char getLifeScore()
    {
        char lifeScore; //현재 학점
        if (health > 100) lifeScore = 'X';
        else if (health >= 90) lifeScore = 'A';
        else if (health >= 80) lifeScore = 'B';
        else if (health >= 70) lifeScore = 'C';
        else if (health >= 60) lifeScore = 'D';
        else lifeScore = 'F';

        return lifeScore;
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if(!isEnterWall)
            transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * 14, ForceMode.Impulse);
            isJump = true;
        }
    }

    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }

    void StopToWall()
    {
        Debug.DrawRay(transform.position, transform.forward * 2, Color.red);
        isEnterWall = Physics.Raycast(transform.position, transform.forward, 2, LayerMask.GetMask("Wall"));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
             isJump = false;
        }
    }

    public void Hit()
    {
        if (!isDamage)
        {
            this.health -= 5;
            foreach(MeshRenderer mesh in meshs)
            {
                mesh.material.color = Color.yellow;
            }
            StartCoroutine(onDamage());
        }
        
    }
    IEnumerator onDamage()
    {
        isDamage = true;
        yield return new WaitForSeconds(1f);
        isDamage = false;
        foreach (MeshRenderer mesh in meshs)
        {
            mesh.material.color = Color.white;
        }
    }
}
