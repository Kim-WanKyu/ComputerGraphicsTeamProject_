using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneButton : MonoBehaviour
{
    [SerializeField]
    private Timer timerScript;

    [SerializeField]
    private GameObject gameEndPanelObject, gameEndTextPanelObject, gameEndButtonPanel;

    private TMP_Text endTitleTxt, endScoreTxt, endDetailTxt, endTimeTxt;
    private Button btnRestart, btnMain;

    // Start is called before the first frame update
    public void Start()
    {
        if (gameEndButtonPanel != null)
        {
            btnRestart = gameEndButtonPanel.transform.GetChild(0).GetComponent<Button>();
            btnMain = gameEndButtonPanel.transform.GetChild(1).GetComponent<Button>();

            btnRestart.onClick.AddListener(gotoGameScene);
            btnMain.onClick.AddListener(gotoMainScene);
        }

        if (gameEndTextPanelObject != null)
        {
            endTitleTxt = gameEndTextPanelObject.transform.GetChild(0).GetComponent<TMP_Text>();
            endScoreTxt = gameEndTextPanelObject.transform.GetChild(1).GetComponent<TMP_Text>();
            endDetailTxt = gameEndTextPanelObject.transform.GetChild(2).GetComponent<TMP_Text>();
            endTimeTxt = gameEndTextPanelObject.transform.GetChild(3).GetComponent<TMP_Text>();
        }

        if (gameEndPanelObject != null)
        {
            if (gameEndPanelObject.activeSelf == true)
                gameEndPanelObject.gameObject.SetActive(false);
        }
        
    }

    //������ �ڵ�
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("clear");
            gameClear();
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("gameFail");
            gameFail();
        }
    }

    public void gameClear()
    {
        endTitleTxt.SetText("Game Clear");
        endScoreTxt.SetText("A");   //getScore�ʿ�
        endDetailTxt.SetText("����� �̹� �б⸦ ������ ���ƽ��ϴ�.");
        endTimeTxt.SetText("�÷���Ÿ��: " + timerScript.GetProgressTime().ToString("F1"));

        endTitleTxt.color = Color.green;
        endScoreTxt.color = Color.black;
        endDetailTxt.color = Color.black;
        endTimeTxt.color = Color.black;

        gameEndPanelObject.gameObject.SetActive(true);
    }

    public void gameFail()
    {
        endTitleTxt.SetText("Game Over");
        endScoreTxt.SetText("F");
        endDetailTxt.SetText("����� �а� ���߽��ϴ�.");
        endTimeTxt.SetText("�÷���Ÿ��: " + timerScript.GetProgressTime().ToString("F1"));

        endTitleTxt.color = Color.red;
        endScoreTxt.color = Color.red;
        endDetailTxt.color = Color.red;
        endTimeTxt.color = Color.red;

        gameEndPanelObject.gameObject.SetActive(true);
    }

    public void gotoGameScene()
    {
        SceneManager.LoadScene("tmpGameScene");
    }

    public void gotoMainScene()
    {
        SceneManager.LoadScene("StartScene");
    }

}
