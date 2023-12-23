using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour
{

    [SerializeField] private bool canSmash = true;
    private float timer = 0f;
    private bool isMovingUp = false;

    void Update()
    {
        if (canSmash)
        {
            timer += Time.deltaTime;

            if (timer >= 1.5f)
            {
                timer = 0f;
                isMovingUp = !isMovingUp;
            }

            var rb = GetComponent<Rigidbody2D>();

            if (isMovingUp)
            {
                Debug.Log("Rebound");
                rb.AddForce(transform.up * 4f); // Aplica força para cima
            }
            else
            {
                Debug.Log("Smash");
                rb.AddForce(-transform.up * 10f); // Aplica força para baixo
            }
        }
    }




}
