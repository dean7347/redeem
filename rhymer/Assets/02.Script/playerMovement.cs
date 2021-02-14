using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
 // 플레이어 이동을 위한 변수들
    public float movePower = 1f;
    public float jumpPower = 1f;
    Rigidbody2D rigid;
    BoxCollider2D boxCollider2D;
    Vector3 movement;
   
    SpriteRenderer spriteRenderer;
    //플레이어 이동을 위한 변수들 끝

    //이동제어 에니메이터
    Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D=gameObject.GetComponent<BoxCollider2D>();
        rigid=gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer= gameObject.GetComponent<SpriteRenderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal")< 0)
        {
            animator.SetInteger("Direction",-1);
            spriteRenderer.flipX=true;
        }
        else if(Input.GetAxisRaw("Horizontal")> 0)
        {
            animator.SetInteger("Direction",1);
            spriteRenderer.flipX=false;
        }
        
        if(Input.GetAxisRaw("Horizontal")!=0)
        {
            animator.SetBool("runState",true);
            
        }
        else
        {
            animator.SetBool("runState",false);
        }
        if(Input.GetButtonDown("Jump")&& !animator.GetBool("isJumpping")) 
        {
            rigid.AddForce(Vector2.up*jumpPower, ForceMode2D.Impulse);
            animator.SetBool("isJumpping",true);
        }
    }
    void FixedUpdate()
    {
        Move();
        //Jump();

        //jump
       
        if(rigid.velocity.y<0 &&(animator.GetBool("isJumpping") ==true))
        {
            //Physics2D.Raycast(rigid.position,Vector3.down,1,LayerMask.GetMask("platform"))
            RaycastHit2D rayHit = Physics2D.BoxCast(boxCollider2D.bounds.center,boxCollider2D.bounds.size,0f,Vector2.down,1f
            ,LayerMask.GetMask("platform"));
            //Debug.Log(rayHit.collider);
            if(rayHit.collider != null)
            {
                Debug.Log(rayHit.distance);
                if(rayHit.distance<0.17f)
                {
                    animator.SetBool("isJumpping",false);
                }
            }
        }

    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        if(Input.GetAxisRaw("Horizontal")<0)
        {
            moveVelocity = Vector3.left;
            
   
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;

        }
        

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    // void Jump()
    // {
    //     if(!isJumping)return;

    //     rigid.velocity=Vector2.zero;
    //     Vector2 jumpVelocity = new Vector2(0,jumpPower);
    //     rigid.AddForce(jumpVelocity,ForceMode2D.Impulse);
    //     isJumping = false;
    // }
}
