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

    private void OnDisable()
    {
        StopCoroutine(onDamage());
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
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && isTouch)
        {
            Player playerController = other.GetComponent<Player>();
            if (playerController != null)
            {
                playerController.Hit();
            }
        }
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
        yield return new WaitForSeconds(1f);
        StartCoroutine(onDamageEnd());
    }

    IEnumerator onDamageEnd()
    {
        anim.SetTrigger("isTouchEnd");
        yield return new WaitForSeconds(1f);
        isTouch = false;
        yield return new WaitForSeconds(4f);
        StartCoroutine(DamageStart());
    }
}
