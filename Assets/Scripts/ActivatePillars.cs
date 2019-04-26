using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePillars : MonoBehaviour
{

    [SerializeField] private GameObject task;
    private bool playedStory = false;

    public void onPickup()
    {
        task.SetActive(true);
        if (!playedStory)
        {
            GameManager.gameManager.GetDialogueHandler().playStory();
            playedStory = true;
        }
    }
}
