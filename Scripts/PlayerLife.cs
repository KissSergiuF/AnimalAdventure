using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
	[SerializeField] private AudioSource deathAudio;
    void Start()
    {
        anim=GetComponent<Animator>();   
        rb=GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Capcana"))
        {
            Die();
        }
    }

    private void Die()
    {
		deathAudio.Play();
        rb.bodyType=RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }   
}
