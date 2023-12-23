using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindZone : MonoBehaviour
{
    [SerializeField] private float windForce = 100f;
    [SerializeField] private bool canWind = false;


    public void SetCanWind()
    {
        this.canWind = !this.canWind;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (canWind)
        {
            var hitobj = other.gameObject;
            if (hitobj != null && other.CompareTag("Player"))
            {
                var rb = hitobj.GetComponent<Rigidbody2D>();
                rb.AddForce(transform.right * windForce);
            }
        }


    }



}