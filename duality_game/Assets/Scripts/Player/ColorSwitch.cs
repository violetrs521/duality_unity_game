using UnityEngine;

namespace Player
{
    public class ColorSwitch : MonoBehaviour
    {
        // Start is called before the first frame update
        public SpriteRenderer Sprite { get; set; }

        void Start()
        {
            Sprite = GetComponent<SpriteRenderer>();
            gameObject.tag = "White";
        }

        public void ReversePlayerColor()
        {
            if (Sprite.color == Color.black)
            {
                Sprite.color = Color.white;
                gameObject.tag = "White";
            }
            else
            {
                Sprite.color = Color.black;
                gameObject.tag = "Black";
            }
        }
    }
}
