using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
 // 플레이어 이동을 위한 변수들
    public float movePower = 1f;
    public float jumpPower = 1f;
    Rigidbody2D rigid;
    Vector3 movement;
    bool isJumping=false;
    SpriteRenderer spriteRenderer;
    //플레이어 이동을 위한 변수들 끝

    //이동제어 에니메이터
    Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
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
        if(Input.GetButtonDown("Jump"))
        {
            isJumping =true;
        }
    }
    void FixedUpdate()
    {
        Move();
        Jump();
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

    void Jump()
    {
        if(!isJumping)return;

        rigid.velocity=Vector2.zero;
        Vector2 jumpVelocity = new Vector2(0,jumpPower);
        rigid.AddForce(jumpVelocity,ForceMode2D.Impulse);
        isJumping = false;
    }
}
