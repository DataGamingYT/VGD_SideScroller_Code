using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public GameObject gameOverScene;
    public AudioClip gameOverSound;


    private void Start()
    {
        gameOverScene.SetActive(false);

    }



    public void GameOver()
    {
        gameOverScene.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);

    }



    public void ResetUI()
    {
        gameOverScene.SetActive(false);
    }
}
