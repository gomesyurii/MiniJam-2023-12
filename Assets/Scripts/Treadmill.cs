using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Treadmill : MonoBehaviour
{
    public bool isLeft;
    public float speed = 1f;
    public Treadmill other;
    public SpriteRenderer directionSprite;
    public bool isChild;
    
#if UNITY_EDITOR
    private void OnValidate()
    {
        if(other is not null) other.isLeft = !isLeft;
        directionSprite.flipX = isLeft;
    }
#endif

    private void OnMouseDown()
    {
        if (isChild) return;
        isLeft = !isLeft;
        if (other is not null)
        {
            other.isLeft = !isLeft;
            other.directionSprite.flipX = !isLeft;
        }
        directionSprite.flipX = isLeft;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Trigger");
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Interactable"))
        {
            Debug.Log("Player");
            Vector3 direction = isLeft ? Vector3.left : Vector3.right;
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            Debug.Log(rb is null);
            rb.AddForce(direction * speed, ForceMode2D.Force);
        }
    }
    
    
}
