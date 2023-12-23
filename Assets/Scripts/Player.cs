using UnityEngine;

public class Player : MonoBehaviour
{
    public ParticleSystem deathParticles;
    public SpriteRenderer spriteRenderer;
    
    public void Die()
    {
        spriteRenderer.enabled = false;
        // deathParticles.Play();
        GameManager.Instance.RestartLevel();
    }
}