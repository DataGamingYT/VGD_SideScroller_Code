using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackCooldown;
    public Transform firePoint;
    public GameObject[] fireballs;
    public AudioClip fireballSound;


    private Animator anim;
    private PlayerController playerController;
    private float coolDownTimer = Mathf.Infinity;


    private void Awake()
    {

        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();

    }


    private void Update()
    {
        if (Input.GetMouseButton(0) && coolDownTimer > attackCooldown && playerController.canAttack())
            Attack();


        coolDownTimer += Time.deltaTime;
    }


    private void Attack()
    {


        SoundManager.instance.PlaySound(fireballSound);
        anim.SetTrigger("attack");
        coolDownTimer = 0;


        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }


    private int FindFireball()
    {
        for(int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
