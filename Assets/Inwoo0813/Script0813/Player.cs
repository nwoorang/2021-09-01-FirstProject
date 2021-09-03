using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5;
    public float jumpUp = 1;
    public Vector3 direction;
    SpriteRenderer sp;
    Animator pAnimator;
    Rigidbody2D pRig2D;

    public GameObject Jdust;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.zero;
        sp = GetComponent<SpriteRenderer>();
        pAnimator = GetComponent<Animator>();
        pRig2D = GetComponent<Rigidbody2D>();

    }

    void KeyInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal");

        if(direction.x <0)
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
    }

    // Update is called once per frame
    void Update()
    {
        KeyInput();
        Move();


        if(Input.GetKeyDown(KeyCode.W))
        {
            if(pAnimator.GetBool("Jump") == false)
            {
                Jump();
                pAnimator.SetBool("Jump", true);
                JumpDust();
            }           
        }

    }

    void JumpDust()
    {
        Instantiate(Jdust, transform.position, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(pRig2D.position, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(pRig2D.position,
            Vector3.down,1,LayerMask.GetMask("Ground"));

        
        if(pRig2D.velocity.y < 0)
        {
            if(rayHit.collider != null)
            {
                if(rayHit.distance <0.7f)
                {
                    pAnimator.SetBool("Jump", false);
                }
            }
        }
    }




    public void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void Jump()
    {
        pRig2D.velocity = Vector2.zero;

        pRig2D.AddForce(new Vector2(0, jumpUp), ForceMode2D.Impulse);
    }


    //달릴때 먼지 
    public void RandDust(GameObject dust)
    {
        Instantiate(dust, transform.position+new Vector3(0,-0.43f,0), Quaternion.identity);
    }


}
