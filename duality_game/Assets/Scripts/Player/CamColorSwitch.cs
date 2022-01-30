using UnityEngine;

namespace Player
{
    public class CamColorSwitch : MonoBehaviour
    {
        public Camera cam;

        // Start is called before the first frame update
        void Start()
        {
            cam = GetComponent<Camera>();
            cam.backgroundColor = Color.black;
        }

        public void ReverseBackgroundColor()
        {
            cam.backgroundColor = cam.backgroundColor == Color.black ? Color.white : Color.black;
        }
    }
}
