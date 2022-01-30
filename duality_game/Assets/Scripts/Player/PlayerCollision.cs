using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        // Object HAS to be called Player
        private GameObject player;
        private SpriteRenderer playerSprite;

        void Start()
        {
            player = GameObject.Find("Player");
            
            playerSprite = player.GetComponent<SpriteRenderer>();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsEnemy(other))
            {
                SceneManager.LoadScene(0);
            }
        }

        private bool IsEnemy(Collider2D other)
        {
            Debug.Log(playerSprite.color);
            var playerColor = playerSprite.color;
            var otherColor = other.gameObject.GetComponent<SpriteRenderer>().color;
            return playerColor != otherColor;
        }
    }
}
