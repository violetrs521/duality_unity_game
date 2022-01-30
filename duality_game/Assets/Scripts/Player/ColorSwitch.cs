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

        // Update is called once per frame
        void Update()
        {
            if ((Input.GetKeyDown(KeyCode.Space)) & Sprite.color == Color.black)
            {
                Sprite.color = Color.white;
                gameObject.tag = "White";
            }

            else if ((Input.GetKeyDown(KeyCode.Space)) & Sprite.color == Color.white)
            {
                Sprite.color = Color.black;
                gameObject.tag = "Black";
            }
        }
    }
}
