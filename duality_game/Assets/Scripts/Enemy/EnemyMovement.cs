using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;
    private Rigidbody2D enemyRigidBody;
    private float newEnemyXPosition;

    // Start is called before the first frame update
    void Start()
    {
        enemySpeed = 10f;

        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        newEnemyXPosition = transform.position.x - enemySpeed * Time.deltaTime;
        transform.position = new Vector3(newEnemyXPosition, transform.position.y, transform.position.z);
    }
}
