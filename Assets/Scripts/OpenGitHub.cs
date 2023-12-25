using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGitHub : MonoBehaviour
{
    public void OpenGit()
    {
        Debug.Log("Opening GitHub");
        Application.OpenURL("https://github.com/gomesyurii");
        Application.OpenURL("https://github.com/guibg");
    }
}
