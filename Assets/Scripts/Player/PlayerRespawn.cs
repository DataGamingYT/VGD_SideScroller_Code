using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public Transform respawnPoint;
    private Health playerHealth;

    private UiManager uiManager;



    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UiManager>();
    }




    public void Respawn()
    {
        uiManager.GameOver();
    }
}
