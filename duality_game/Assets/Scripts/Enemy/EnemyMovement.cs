using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;
    private Rigidbody2D enemyRigidBody;
    private float newEnemyXPosition;

    private Camera MainCamera;
    private Vector2 screenBounds;
    private Vector3 despawnZone;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;

        enemySpeed = 10f;

        enemyRigidBody = GetComponent<Rigidbody2D>();

        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

        despawnZone = new Vector3(screenBounds.x - (screenBounds.x * 2f),0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        newEnemyXPosition = transform.position.x - enemySpeed * Time.deltaTime;
        if (newEnemyXPosition <= despawnZone.x)
        {
            Destroy(this.gameObject);
        } else {
            transform.position = new Vector3(newEnemyXPosition, transform.position.y, transform.position.z);
        }
    }
}
