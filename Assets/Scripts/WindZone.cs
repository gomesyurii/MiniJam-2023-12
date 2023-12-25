using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindZone : MonoBehaviour
{
    [SerializeField] private float windForce = 100f;
    [SerializeField] private bool canWind = false;
    [SerializeField] private SpriteRenderer buttonSprite;
    [SerializeField] private bool startWithWind = false;

    void Start()
    {
        if (startWithWind)
        {
            buttonSprite.color = Color.green;
            canWind = true;
        }
        else
        {
            buttonSprite.color = Color.red;
            canWind = false;
        }
    }

    public void SetCanWind()
    {
        this.canWind = !this.canWind;
        if (this.canWind)
        {
            buttonSprite.color = Color.green;
        }
        else
        {
            buttonSprite.color = Color.red;
        }
    }

    private void OnMouseDown()
    {
        SetCanWind();
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