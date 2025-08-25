using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;
using TMPro;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        string name = DataManager.Instance.bestName;
        int points = DataManager.Instance.bestScore;

        bestScoreText.text = $"Best Score : {name} : {points}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMain()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitPlayMode()
    {
        //MainManager.Instance.SaveColor();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
