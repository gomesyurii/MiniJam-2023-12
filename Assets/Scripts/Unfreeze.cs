using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unfreeze : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.CompareTag("Player"))
        {
            Debug.Log("unfreeze");

            // Animation here (if needed)

            // Load the next level scene
            SceneManager.LoadScene("Level" + (gameManager.level + 1));
 
            // Increment the level value
            gameManager.level++;
        }
    }
}

