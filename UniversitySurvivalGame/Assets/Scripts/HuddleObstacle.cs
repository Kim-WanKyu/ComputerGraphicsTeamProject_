using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuddleObstacle : MonoBehaviour
{    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player playerController = other.GetComponent<Player>();
            if (playerController != null)
            {
                playerController.Hit();
            }
        }
        Debug.Log("허들과 충돌한 물체 :" + other);
     }
}