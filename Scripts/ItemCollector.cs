using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class itemCollector : MonoBehaviour
{
    private int contor = 0;

    [SerializeField] private Text fructeText;
	[SerializeField] private AudioSource collectAudio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pepene"))
        {
			collectAudio.Play();
            Destroy(collision.gameObject);
            contor++;
            fructeText.text = "Fructe: " + contor;

        }
    }
}
