using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLineCollide : MonoBehaviour
{
    [SerializeField]
    private Timer timerScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            timerScript.SetCollideGoalLine(true);
        }
    }
}
