using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    public Transform respawnPoint;
    public UiManager GameOver();



    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();

    }


    public void TakeDamage(float _damage)
    {


        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, 100);


        if (currentHealth > 0)
        {
            //Player takes damage
            anim.SetTrigger("hurt");


        }

        else
        {
            if (!dead)
            {


                anim.SetTrigger("dead");
                GetComponent<PlayerController>().enabled = false;
                dead = true;
                GameOver();



            }

            //gameObject.gameObject.SetActive(false);
        }




    }



    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
            TakeDamage(1);
    }



    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, 100);
    }


    public void Respawn()
    {
        dead = false;
        FindObjectOfType<PlayerController>().Move2Respawn();
        GetComponent<PlayerController>().enabled = true;
        AddHealth(startingHealth);
        anim.ResetTrigger("dead");
        anim.Play("Idle");

    }


}
