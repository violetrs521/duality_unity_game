using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private GameObject player;
        private ColorSwitch script;

        void Start()
        {
            player = GameObject.Find("Player");
            script = player.GetComponent<ColorSwitch>();
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
            var playerColor = script.Sprite.color;
            var otherColor = other.gameObject.GetComponent<SpriteRenderer>().color;
            return playerColor != otherColor;
        }
    }
}
