using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance;
    public float level = 1;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel(0f);
        }
    }
    
    public void CallLevel1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    public void RestartLevel(float delay = 1f) 
    {
        StartCoroutine(RestartLevelCoroutine(delay));
    }

    private IEnumerator RestartLevelCoroutine(float delay = 1f)
    {
        yield return new WaitForSeconds(delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene()
            .buildIndex);
    }
}