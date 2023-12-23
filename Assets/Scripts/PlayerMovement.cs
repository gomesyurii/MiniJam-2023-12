using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb; 
    public bool isGrounded = true;
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
        isGrounded = IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Pular();
        }
    }


    void Pular()
    {
        // Adiciona uma força vertical para simular o pulo
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {

        float distance = 0.5f;

        // The layer mask to hit only the ground layer
        int layerMask = LayerMask.GetMask("Ground");

        // Move the start point of the raycast up a bit
        Vector3 startPoint = transform.position + new Vector3(0, 0.1f, 0);

        // Perform the raycast
        RaycastHit2D hit = Physics2D.Raycast(startPoint, Vector2.down, distance, layerMask);
        Debug.DrawRay(startPoint, Vector2.down * distance, Color.red);

        // If the raycast hit something, the player is grounded
        return hit.collider != null;
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

        if (direction == 1)
        {
            transform.localScale = new Vector3(5, 5, 5); // Virar para a direita
        }
        else if (direction == -1)
        {
            transform.localScale = new Vector3(-5, 5, 5); // Virar para a esquerda
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

        if (rb.velocity.x != 0)
        {
            isWalking = true;


        }
        else
        {
            isWalking = false;

        }
    }


}
