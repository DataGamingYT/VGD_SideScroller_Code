using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Lumin;

public class Restart : MonoBehaviour
{


    public GameObject gameOverScreen;

    public void ClickMe()
    {

        FindObjectOfType<Health>().Respawn();
        FindObjectOfType <UiManager>().ResetUI();
    }

}
