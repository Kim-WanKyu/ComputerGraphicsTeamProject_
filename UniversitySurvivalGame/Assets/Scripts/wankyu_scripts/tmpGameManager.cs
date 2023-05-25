using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    float timeLimit = 20.0f;
    float timer;
    Text textTimer;

    int life;
    Text lifeGrade;

    // Start is called before the first frame update
    void Start()
    {
        timer = timeLimit;
        life = 4;
        StartCoroutine(Timer(timer));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(life <= 0)
        {
            
        }
    }


    IEnumerator Timer (float time)
    {
        while(time > 0)
        {
            timer -= Time.deltaTime;
            textTimer.text = "" + timer.ToString("F1");
            yield return null;
        }
        time = 0;
        textTimer.text = "Time : " + time.ToString("F1");
    }
}
