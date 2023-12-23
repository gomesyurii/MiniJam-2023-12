using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareKill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Die();
        }
    }
}
