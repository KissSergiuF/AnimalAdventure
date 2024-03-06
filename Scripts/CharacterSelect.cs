using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterSelect : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter;
    
    
    private void Awake()
    {
        foreach (GameObject player in characters)
            player.SetActive(false);
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        characters[selectedCharacter].SetActive(true);
    }
    public void changeNext()
    {
        characters[selectedCharacter].SetActive(false);
        if(selectedCharacter==characters.Length-1)
            selectedCharacter = 0;
        else
            selectedCharacter++;
        characters[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }

    public void changePrevious()
    {
        characters[selectedCharacter].SetActive(false);
        if(selectedCharacter==0)
            selectedCharacter = characters.Length-1;
        else
            selectedCharacter--;
        characters[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }
}