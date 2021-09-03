using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player001 : MonoBehaviour
{
    //대쉬
    public float dashspeed;
    public float dashtime;
    public float startdashtime;
    private int direction2;



    public float speed = 1;
    public float jumpUp = 9;
    public Vector3 direction;
    SpriteRenderer sp;
    Animator pAnimator;
    Rigidbody2D pRig2D;


    // Start is called before the first frame update
    void Start()
    {
        dashtime = startdashtime;

        direction = Vector2.zero;
        sp = GetComponent<SpriteRenderer>();
        pAnimator = GetComponent<Animator>();
        pRig2D = GetComponent<Rigidbody2D>();

    }

    void KeyInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        if (direction.x < 0)
        {
            sp.flipX = true;
            pAnimator.SetBool("Run", true);
        }
        else if(direction.x >0)
        {
            sp.flipX = false;
            pAnimator.SetBool("Run", true);
        }
        else if(direction.x == 0)
        {
            pAnimator.SetBool("Run", false);
        }

        if(Input.GetKeyDown(KeyCode.J))
            {
            pAnimator.SetTrigger("Attack");
        }

       

    }

    // Update is called once per frame
    void Update()
    {
        KeyInput();
        Move();
       


        if(direction2 == 0)
        {
            if(Input.GetKeyDown(KeyCode.K))
            {
                pAnimator.SetTrigger("Dash");

                if (direction.x < 0)
                {
                    direction2 = 1;
                }
                else if(direction.x > 0)
                {
                    direction2 = 2;
                }
            }
        }
        else
        {
            if(dashtime <= 0)
            {
                direction2 = 0;
                dashtime = startdashtime;
                pRig2D.velocity = Vector2.zero;
            }
            else
            {
                dashtime -= Time.deltaTime;

                if(direction2 ==  1)
                {
                    pRig2D.velocity = Vector2.left * dashspeed;
                }
                else if(direction2 == 2)
                {
                    pRig2D.velocity = Vector2.right * dashspeed;
                }
            }
        }

        
    }





    public void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }


}
