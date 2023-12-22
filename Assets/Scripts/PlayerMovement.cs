using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isGrounded = false;
    public bool isWalking = false;
    public int direction;
    private float speed = 5f;
    private float jumpForce = 3f;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    void Update()
    {
        if (direction == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Rotaciona o personagem para a direita
        }
        else if (direction == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Rotaciona o personagem para a esquerda
        }

        if (Physics2D.gravity.y < 0)
        {
            // Se a gravidade for negativa, rotacione o personagem para andar no teto
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(180, 0, 0);
        }
    }


    public void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if (x != 0)
        {
            direction = x > 0 ? 1 : -1;
        }


        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        if (rb.velocity.x != 0)
        {
            isWalking = true;


        }
        else
        {
            isWalking = false;

        }

        if (rb.velocity.y == 0)
        {
            isGrounded = true;
        }

    }


}
