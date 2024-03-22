using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBar: MonoBehaviour
{


    public Health playerHealth;
    public UnityEngine.UI.Image totalHeartBar;
    public UnityEngine.UI.Image currentHeartBar;


    private void Start()
    {
        currentHeartBar.fillAmount = playerHealth.currentHealth / 10;
    }




    private void Update()
    {
        currentHeartBar.fillAmount = playerHealth.currentHealth / 10;
    }


}
