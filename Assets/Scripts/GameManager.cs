using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance;
    
    private void Awake()
    {
        Instance = this;
    }
    
    public void RestartLevel()
    {
        StartCoroutine(RestartLevelCoroutine());
    }
    
    private IEnumerator RestartLevelCoroutine()
    {
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}