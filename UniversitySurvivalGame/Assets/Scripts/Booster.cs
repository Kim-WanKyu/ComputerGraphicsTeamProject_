using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public float boostspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player playerController = other.GetComponent<Player>();
            if (playerController != null && playerController.speed < 20)
            {
                playerController.speed += boostspeed;
                StartCoroutine(onBoost(other));
       
            }
        }
        Debug.Log("부스터 먹음 속도 향상 :"+other);
    }
    IEnumerator onBoost(Collider other)
    {
        Player playerController = other.GetComponent<Player>();
        yield return new WaitForSeconds(2f);
        playerController.speed -= boostspeed;
    }

}
