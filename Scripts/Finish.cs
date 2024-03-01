using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Finish : MonoBehaviour
{
    private AudioSource finishAudio;
    private bool isFinished = false;
    private void Start()
    {
        finishAudio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !isFinished)
        {
            isFinished = true;
            finishAudio.Play();
            Invoke("CompleteLevel", 2f);
            CompleteLevel();
            
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
