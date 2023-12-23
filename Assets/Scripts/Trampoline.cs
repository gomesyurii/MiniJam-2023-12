using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trampolin : MonoBehaviour
{

    [SerializeField] private float jumpForce = 100f;
    void OnCollisionEnter2D(Collision2D other)
    {
        var hitobj = other.gameObject;
        Debug.Log(hitobj == null);
        if (hitobj != null && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jump");
            var rb = hitobj.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * jumpForce);
        }
    }
}