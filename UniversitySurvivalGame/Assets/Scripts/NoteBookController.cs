using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBookController : MonoBehaviour
{
    Animator anim;
    bool isTouch;

    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
        anim = GetComponentInChildren<Animator>();
        StartCoroutine(onDamage());
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isTouch)
        {
            Player playerController = other.GetComponent<Player>();
            if (playerController != null)
            {
                playerController.Hit();
            }
        }
        Debug.Log("노트북과 충돌한 물체 :" + other);
        
    }
    

    IEnumerator DamageStart()
    {
        yield return null;
        StartCoroutine(onDamage());
    }

    IEnumerator onDamage()
    {
        isTouch = true;
        anim.SetTrigger("isTouch");
        yield return new WaitForSeconds(2f);
        StartCoroutine(onDamageEnd());
    }
    IEnumerator onDamageEnd()
    {
        anim.SetTrigger("isTouchEnd");  
        isTouch = false;
        yield return new WaitForSeconds(4f);
        StartCoroutine(DamageStart());
    }
}
