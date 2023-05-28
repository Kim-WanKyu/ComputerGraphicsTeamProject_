using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    [SerializeField]
    private GameObject goalLine, playerObject;

    [SerializeField]
    private GameObject progressBarObject;

    private Slider progressBar;

    IEnumerator progressEnumerator;

    // Start is called before the first frame update
    void Start()
    {
        progressBar = progressBarObject.GetComponent<Slider>();
        progressBar.maxValue = goalLine.transform.position.z;

        progressEnumerator = ProgressCoroutine();
        StartCoroutine(progressEnumerator);
    }

    IEnumerator ProgressCoroutine()
    {
        while (true)
        {
            progressBar.value = playerObject.transform.position.z;

            yield return null;
        }
    }
}
