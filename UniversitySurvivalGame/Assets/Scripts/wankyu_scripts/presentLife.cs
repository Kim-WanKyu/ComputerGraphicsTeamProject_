using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class presentLife : MonoBehaviour
{
    [SerializeField]
    private Player playerScript;

    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    private GameObject remainLifeTxtObject;

    private TMP_Text remainLifeTxt;

    IEnumerator presentLifeEnumerator;

    // Start is called before the first frame update
    void Start()
    {
        remainLifeTxt = remainLifeTxtObject.GetComponent<TMP_Text>();

        presentLifeEnumerator = showPresentScoreCoroutine();
        StartCoroutine(presentLifeEnumerator);
    }

    IEnumerator showPresentScoreCoroutine()
    {
        while (true)
        {
            remainLifeTxt.text = "현재 학점\n" + playerScript.getLifeScore();

            yield return null;
        }
    }
}
