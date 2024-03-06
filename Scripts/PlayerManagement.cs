using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController controllerPlayer1;
    [SerializeField] private RuntimeAnimatorController controllerPlayer2;
    [SerializeField] private RuntimeAnimatorController controllerPlayer3;
    private Animator animator;
    private void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        animator = GetComponent<Animator>();
        if (selectedCharacter == 0)
        {
            animator.runtimeAnimatorController = controllerPlayer1;
        }
        else if (selectedCharacter == 1)
        {
            animator.runtimeAnimatorController = controllerPlayer2;
        }
        else if (selectedCharacter == 2)
        {
            animator.runtimeAnimatorController = controllerPlayer3;
        }
    }
}