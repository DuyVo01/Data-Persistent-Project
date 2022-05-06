using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneManage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MainSceneLoader()
    {
        PlayerManager.Instance.SetName();
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

    
    public void Exit()
    {
        PlayerManager.Instance.SavePlayerData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
