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
    GameObject gameObject;
    [Serialize]
    private Button btnStart, btnExit;


    // Start is called before the first frame update
    public void Start()
    {
        btnStart.onClick.AddListener(ChangeMainScene);
        btnExit.onClick.AddListener(ExitScene);
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
