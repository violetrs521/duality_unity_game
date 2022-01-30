using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsEnemy(other.gameObject))
            {
                SceneManager.LoadScene(0);
            }
        }

        private bool IsEnemy(GameObject other)
        {
            return !gameObject.CompareTag(other.tag);
        }
    }
}
