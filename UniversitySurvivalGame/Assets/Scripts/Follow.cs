using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;

    private Vector3 topOffset = new Vector3(0, 35, 0);     //위에서 바라볼 때 카메라 오프셋
    private Vector3 backOffset = new Vector3(0, 10, -20);   //뒤에서 바라볼 때 카메라 오프셋

    [SerializeField]
    private Light sunlight;

    // Start is called before the first frame update
    void Start()
    {
        SetBackOffset();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        transform.LookAt(target);

        sunlight.transform.position = transform.position + topOffset;
        sunlight.transform.LookAt(target);
    }

    public void SetTopOffset()
    {
        StartCoroutine(ChangeTopViewCoroutine());
    }
    public void SetBackOffset()
    {
        StartCoroutine(ChangeBackViewCoroutine());
    }

    IEnumerator ChangeTopViewCoroutine()
    {
        Vector3 fromOffset, toOffset;
        fromOffset = backOffset;
        toOffset = topOffset;

        float time = 0f;
        float duration = 1f;

        while (time < duration)
        {
            offset = Vector3.Lerp(fromOffset, toOffset, time / duration);
            time += Time.deltaTime;

            yield return null;
        }

        offset = topOffset;
    }

    IEnumerator ChangeBackViewCoroutine()
    {
        Vector3 fromOffset, toOffset;
        fromOffset = topOffset;
        toOffset = backOffset;

        float time = 0f;
        float duration = 0.5f;

        while (time < duration)
        {
            offset = Vector3.Lerp(fromOffset, toOffset, time / duration);
            time += Time.deltaTime;

            yield return null;
        }

        offset = backOffset;
    }
}