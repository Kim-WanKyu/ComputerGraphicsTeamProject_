using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private GameObject remainTimeTxtObject, remainTimeBarObject;

    private TMP_Text remainTimeTxt;
    private Image timerBar;

    private float rr, gg;    //bb = 0

    private float remainTime, timer, endRecord;
    private bool isCollideGoalLine, isFinish;

    public float GetRemainTime() { return remainTime; }
    public float GetTimer() { return timer; }
    public void SetEndRecord(float endtime) { endRecord = endtime; }
    public void IsCollideGoalLine() { isCollideGoalLine = true; }

    IEnumerator timeEnumerator;
    IEnumerator finishEnumerator;

    // Start is called before the first frame update
    void Start()
    {
        isCollideGoalLine = isFinish = false;

        remainTime = 120f;  //���� �ð�
        timer = remainTime; //Ÿ�̸�

        remainTimeTxt = remainTimeTxtObject.GetComponent<TMP_Text>();
        timerBar = remainTimeBarObject.GetComponent<Image>();

        timeEnumerator = TimerCoroutine();
        StartCoroutine(timeEnumerator);
    }

    private void Update()
    {
        if (timer <= 0)
        {
            StopCoroutine(timeEnumerator);
            //Time.timeScale = 0;
        }
        if (isCollideGoalLine && !isFinish)
        {
            isFinish = true;
            finishEnumerator = finishCoroutine();
            StartCoroutine(finishEnumerator);
            StopCoroutine(timeEnumerator);
        }
    }


    IEnumerator finishCoroutine()
    {
        Debug.Log("����"+ endRecord+"����ð�"+(remainTime-endRecord).ToString());
        StopCoroutine(finishEnumerator);
        yield return null;
    }

    IEnumerator TimerCoroutine()
    {
        rr = 0;
        gg = 1;
        while (timer >= 0)
        {
            if (timer > remainTime / 2)
            {
                rr += (Time.deltaTime / (remainTime / 2));
            }
            else
            {
                gg -= (Time.deltaTime / (remainTime / 2));
            }

            timer -= Time.deltaTime;
            remainTimeTxt.text = "���� �ð�(s)\n" + timer.ToString("F1");
            timerBar.fillAmount = timer / remainTime;
            timerBar.color = new Color(rr, gg, 0);

            yield return null;
        }
    }
}
