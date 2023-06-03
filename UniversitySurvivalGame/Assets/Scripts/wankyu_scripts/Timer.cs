using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private GameObject remainTimeTxtObject;

    private TMP_Text remainTimeTxt;

    private float timer;
    private bool isCollideGoalLine, isFinish;

    public float GetTimer() { return timer; }
    public void SetCollideGoalLine(bool isCollide) { isCollideGoalLine = isCollide; }
    public bool GetIsFinish() { return isFinish; }
    
    IEnumerator timeEnumerator;

    // Start is called before the first frame update
    void Start()
    {
        isCollideGoalLine = isFinish = false;

        timer = 0;

        remainTimeTxt = remainTimeTxtObject.GetComponent<TMP_Text>();

        timeEnumerator = TimerCoroutine();
        StartCoroutine(timeEnumerator);
    }

    private void Update()
    {
        if (isCollideGoalLine && !isFinish)
        {
            isFinish = true;
            Debug.Log("진행시간" + timer.ToString("F1"));
            StopCoroutine(timeEnumerator);
        }
    }

    IEnumerator TimerCoroutine()
    {
        while (timer >= 0)
        {
            timer += Time.deltaTime;
            remainTimeTxt.text = "진행 시간(s)\n" + timer.ToString("F1");

            yield return null;
        }
    }
}
