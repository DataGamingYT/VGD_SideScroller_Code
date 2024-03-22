using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerController>().Miss1();
        }
    }
}
