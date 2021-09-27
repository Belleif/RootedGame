using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMove : MonoBehaviour
{

    public Rigidbody2D theRB;
    public float moveSpeed = 2f;
    public float jumpHeight = 2f;

    public BoxCollider2D playerBox;

    public LayerMask platformLayerMask;
    private SpriteRenderer mySpriteRenderer;
    private Animator myanim;
    public bool jumping = false;

    private void Start()
    {
        theRB = gameObject.GetComponent<Rigidbody2D>();
        mySpriteRenderer = this.GetComponent<SpriteRenderer>();

        myanim = this.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        IsGrounded();
        if (IsGrounded())
        {
            jumping = false;
        }
        else
        {
            jumping = true;
        }
        Jump();

        Vector3 knightMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        transform.position += knightMovement * Time.deltaTime * moveSpeed;

        //if (Input.GetAxisRaw("Horizontal") < -.01f && !jumping)
        // {
        //     gameObject.GetComponent<Animator>().Play("knight_walk_left");
        //  }


        if (!jumping)
        {
            if (Input.GetAxisRaw("Horizontal") > .01f) 
            {
                myanim.SetBool("jumpNow", false);
                myanim.SetBool("isWalkingRight", true);
                myanim.SetBool("isWalkingLeft", false);
            }
            else if (Input.GetAxisRaw("Horizontal") < -.01f)
            {
                myanim.SetBool("jumpNow", false);
                myanim.SetBool("isWalkingRight", false);
                myanim.SetBool("isWalkingLeft", true);
            }
            else
            {
                myanim.SetBool("jumpNow", false);
                myanim.SetBool("isWalkingRight", false);
                myanim.SetBool("isWalkingLeft", false);
            }
        }
        else
        {
            if (Input.GetAxisRaw("Horizontal") > .01f)
            {
                myanim.SetBool("jumpNow", true);
                myanim.SetBool("isWalkingRight", true);
                myanim.SetBool("isWalkingLeft", false);
            }
            else if (Input.GetAxisRaw("Horizontal") < -.01f)
            {
                myanim.SetBool("jumpNow", true);
                myanim.SetBool("isWalkingRight", false);
                myanim.SetBool("isWalkingLeft", true);
            }
            else
            {
                myanim.SetBool("jumpNow", true);
                myanim.SetBool("isWalkingRight", false);
                myanim.SetBool("isWalkingLeft", false);
            }
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown ("Jump") && IsGrounded() )
        {
            jumping = true;
            theRB.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);

        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D rayHitsPlatform = Physics2D.BoxCast(playerBox.bounds.center, playerBox.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);

        return rayHitsPlatform.collider != null;
    }
}
