using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindZone : MonoBehaviour
{
    [SerializeField] private float windForce = 1000f;
    [SerializeField] private bool canWind = true;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (canWind)
        {
            var hitobj = other.gameObject;
            if (hitobj != null && other.CompareTag("Player"))
            {
                Debug.Log("Wind");
                var rb = hitobj.GetComponent<Rigidbody2D>();
                Debug.Log(rb.name);
                rb.AddForce(transform.right * windForce);
            }
        }


    }



}