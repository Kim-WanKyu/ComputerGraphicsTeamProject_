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
    private Button btnStart, btnInstruction, btnExit;
    

    // Start is called before the first frame update
    public void Start()
    {
        btnStart = transform.GetChild(0).GetComponent<Button>();
        btnInstruction = transform.GetChild(1).GetComponent<Button>();
        btnExit = transform.GetChild(2).GetComponent<Button>();

        btnStart.onClick.AddListener(ChangeMainScene);
        btnInstruction.onClick.AddListener(ExitScene);  //
        btnExit.onClick.AddListener(ExitScene);
    }

    public void OpenInstuction()
    {
        //
    }

    public void ChangeMainScene()
    {
        SceneManager.LoadScene("tmpGameScene");
    }

    public void ExitScene()
    {
        Application.Quit();
    }

}
