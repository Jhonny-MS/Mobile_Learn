using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{      
    public void Restart(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void Restart(string s)
    {
        SceneManager.LoadScene(s);
    }
}
