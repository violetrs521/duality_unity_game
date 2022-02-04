using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float enemySpeed;
    private float increaseEnemySpeedRate;

    private Rigidbody2D enemyRigidBody;
    private float newEnemyXPosition;

    private Camera MainCamera;
    private Vector2 screenBounds;
    private Vector3 despawnZone;

    private PlayerScoreDisplay playerScoreScript;
    private EnemySpawn enemySpawnScript;
    public int prevScoreAtDifficultyIncrease { get; set; }
    private int score;
    private int increaseDifficultyOnLevel;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;

        enemyRigidBody = GetComponent<Rigidbody2D>();

        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

        despawnZone = new Vector3(screenBounds.x - (screenBounds.x * 2f),0f,0f);

        playerScoreScript = GameObject.Find("Score").GetComponent<PlayerScoreDisplay>();

        score = playerScoreScript.Score;

        enemySpawnScript = GameObject.Find("EnemySpawn").GetComponent<EnemySpawn>();

        enemySpeed = enemySpawnScript.enemySpeed;
        increaseEnemySpeedRate = enemySpawnScript.increaseEnemySpeedRate;
        prevScoreAtDifficultyIncrease = enemySpawnScript.prevScoreAtDifficultyIncrease;
        increaseDifficultyOnLevel = enemySpawnScript.increaseDifficultyOnLevel;
    }

    // Update is called once per frame
    void Update()
    {
        score = playerScoreScript.Score;
        if (score != 0 & score % increaseDifficultyOnLevel == 0 & score != prevScoreAtDifficultyIncrease)
        {
            prevScoreAtDifficultyIncrease = score;
            enemySpeed *= increaseEnemySpeedRate;
        }
        newEnemyXPosition = transform.position.x - enemySpeed * Time.deltaTime;
        if (newEnemyXPosition <= despawnZone.x)
        {
            Destroy(this.gameObject);
        } else {
            transform.position = new Vector3(newEnemyXPosition, transform.position.y, transform.position.z);
        }
    }
}
