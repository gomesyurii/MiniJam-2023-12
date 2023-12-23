using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform exitPoint;
    private bool isActive;
    public SpriteRenderer spriteRenderer;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("IsActive: " + isActive);
        if (!isActive) return;
        if (other.CompareTag("Player") || other.CompareTag("Interactable"))
        {
            PortalManager.Instance.Teletransport(other.gameObject, this);
            StartCoroutine(DeactivatePortal1Frame());
        }
    }

    private void OnMouseDown()
    {
        if (!PortalManager.Instance.CanSpawnPortal()) return;
        isActive = !isActive;
        spriteRenderer.color = isActive ? PortalManager.Instance.SetPortal(this) : Color.white;
    }
    
    public void Deactivate()
    {
        isActive = false;
        spriteRenderer.color = Color.white;
    }
    
    private IEnumerator DeactivatePortal1Frame()
    {
        isActive = false;
        yield return new WaitForSeconds(0.1f);
        isActive = true;
    }
    
}