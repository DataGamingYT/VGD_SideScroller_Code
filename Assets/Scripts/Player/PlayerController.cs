using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    [SerializeField] private float jumpPower;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private float wallJumpCooldown;

    private BoxCollider2D boxCollider;

    private float horizontalInput;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        boxCollider = GetComponent<BoxCollider2D>();

    }


    private void Update()
    {


       horizontalInput = Input.GetAxis("Horizontal");




        //Flip Player 
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;


        else if (horizontalInput < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);









        //Set animantor Paramenters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        if(wallJumpCooldown > 0.2f)
        {


            //Getting info from Arrows
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;

            }
            else
                body.gravityScale = 1.2f;
        }else
            wallJumpCooldown += Time.deltaTime;


        if (Input.GetKey(KeyCode.Space))
            Jump();
                


    }


    private void Jump()
    {

        

        if (isGrounded())
        {


            body.velocity = new Vector2(body.velocity.x, speed);
            anim.SetTrigger("jump");

        }

        else if (onWall() && isGrounded())
        {

            if(horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            } else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            wallJumpCooldown = 0;

        }

    }


   //  private void OnCollisionEnter2D(Collision2D collision)
  //  {
   //     if (collision.gameObject.tag == "Ground")
     //       grounded = true;
  //  }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
            return raycastHit.collider != null;

    }


    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;

    }


    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() == true && !onWall();

    }



    public void Miss1()
    {
        FindObjectOfType<Health>().TakeDamage(3);
        this.transform.position = new Vector3(-40, -6, 0);
    }



    public void Move2Respawn()
    {
        this.transform.position = new Vector3(-40, -6, 0);
    }

}
