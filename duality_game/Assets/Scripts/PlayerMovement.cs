using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called once per physics tick

    void FixedUpdate()
    {       
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        Move();
    }

    void Move()
    {
        if (change != Vector3.zero)
        {
            myRigidBody.MovePosition(transform.position + change.normalized * (Time.deltaTime * speed));
        }
    }
}
