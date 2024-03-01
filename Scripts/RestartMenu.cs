using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartMenu : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Restart");
    }
}
