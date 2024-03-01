using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    [SerializeField] private Text nivelText;
    void Start()
    {
        int nivelCurent = SceneManager.GetActiveScene().buildIndex;
        nivelText.text = "Nivel: " + nivelCurent;
    }
}