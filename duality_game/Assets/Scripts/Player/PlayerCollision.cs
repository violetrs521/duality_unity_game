using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        public GameObject mainCamera;
        public PlayerScoreDisplay scoreScript;

        private void Start()
        {
            mainCamera = GameObject.FindWithTag("MainCamera");
            scoreScript = GameObject.Find("Score").GetComponent<PlayerScoreDisplay>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsEnemy(other.gameObject))
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Destroy(other.gameObject);
                scoreScript.IncreasePoints(1);
                ReverseColors();
            }
        }

        private bool IsEnemy(GameObject other)
        {
            return !gameObject.CompareTag(other.tag);
        }

        private void ReverseColors()
        {
            // reverse player color and background color
            ReversePlayerColor();
            ReverseBackgroundColor();
            ReverseScoreColor();
        }

        private void ReversePlayerColor()
        {
            gameObject.GetComponent<ColorSwitch>().ReversePlayerColor();
        }

        private void ReverseBackgroundColor()
        {
            mainCamera.GetComponent<CamColorSwitch>().ReverseBackgroundColor();
        }
        
        private void ReverseScoreColor()
        {
            scoreScript.ReverseScoreColor();
        }
    }
}
