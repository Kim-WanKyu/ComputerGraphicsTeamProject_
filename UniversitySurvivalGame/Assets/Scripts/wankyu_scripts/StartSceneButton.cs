using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneButton : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPanelObject, instructionPanelObject;

    private Button btnStart, btnInstruction, btnQuit, btnInsExit;

    // Start is called before the first frame update
    public void Start()
    {
        if (buttonPanelObject != null)
        {
            btnStart = buttonPanelObject.transform.GetChild(0).GetComponent<Button>();
            btnInstruction = buttonPanelObject.transform.GetChild(1).GetComponent<Button>();
            btnQuit = buttonPanelObject.transform.GetChild(2).GetComponent<Button>();

            btnStart.onClick.AddListener(gotoGameScene);
            btnInstruction.onClick.AddListener(OpenInstuction);
            btnQuit.onClick.AddListener(ExitScene);
        }

        if (instructionPanelObject != null)
        {
            btnInsExit = instructionPanelObject.transform.GetChild(2).GetComponent<Button>();

            btnInsExit.onClick.AddListener(CloseInstuction);
            if (instructionPanelObject.activeSelf == true)
                instructionPanelObject.gameObject.SetActive(false);
        }

    }

    public void OpenInstuction()
    {
        if (instructionPanelObject != null)
        {
            if (instructionPanelObject.gameObject.activeSelf == false)
            {
                instructionPanelObject.gameObject.SetActive(true);
                btnStart.enabled = false;
                btnInstruction.enabled = false;
                btnQuit.enabled = false;
            }
        }
    }
    public void CloseInstuction()
    {
        if (instructionPanelObject != null)
        {
            if (instructionPanelObject.gameObject.activeSelf == true)
            {
                instructionPanelObject.gameObject.SetActive(false);
                btnStart.enabled = true;
                btnInstruction.enabled = true;
                btnQuit.enabled = true;
            }
        }
    }

    public void gotoGameScene()
    {
        SceneManager.LoadScene("tmpGameScene");
    }

    public void ExitScene()
    {
        Application.Quit();
    }

}
