using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTopView : MonoBehaviour
{
    [SerializeField]
    private Follow followScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player playerController = other.GetComponent<Player>();
            if (playerController != null)
            {
                followScript.SetTopOffset();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Player playerController = other.GetComponent<Player>();
            if (playerController != null)
            {

                followScript.SetBackOffset();
            }
        }
    }
}
