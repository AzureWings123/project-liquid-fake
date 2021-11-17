using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rd;

    private Vector2 moveVelocity;

    private SpriteRenderer spriteRenderer;

    void Start(){
        rd = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update() {

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(Input.GetAxis("Horizontal") > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            spriteRenderer.flipX = false;
        }
        moveVelocity = moveInput * speed;
    }

   void FixedUpdate(){

        rd.MovePosition(rd.position + moveVelocity * Time.fixedDeltaTime);

    }
}
