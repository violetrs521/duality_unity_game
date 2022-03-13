using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    private GameObject newEnemy;
    private EnemyMovement newEnemyMovementScript;
    public SpriteRenderer enemySpriteRenderer {get; set;}
    private Vector3 enemySpawnPosition;
    private int numberOfPotentialSpawns;
    private int randomSpawnLocation;
    private float baseEnemySpawnSpeed;
    private float enemySpawnRate;
    private float enemySpawnRateChange;

    public Sprite whiteCircleBlackBorder;
    public Sprite blackCircleWhiteBorder;

    private Camera MainCamera;
    private Vector2 screenBounds;

    private PlayerScoreDisplay playerScoreScript;
    
    public int prevScoreAtDifficultyIncrease { get; set; }
    public float enemySpeed { get; set; }
    public float maxEnemySpeed { get; set; }
    public int increaseDifficultyOnLevel { get; set; }

    private const float E = 2.7182818284590451f;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;

        enemySpawnRate = 0.5f;
        enemySpawnRateChange = 0.75f;

        maxEnemySpeed = 15f;
        enemySpeed = 5f;
        prevScoreAtDifficultyIncrease = -1;
        increaseDifficultyOnLevel = 10;

        numberOfPotentialSpawns = 8;

        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));

        playerScoreScript = GameObject.Find("Score").GetComponent<PlayerScoreDisplay>();

        repeatingEnemySpawn();
    }

    private void SpawnNewEnemy()
    {
        randomSpawnLocation = Random.Range(1,numberOfPotentialSpawns + 1);
        enemySpawnPosition = new Vector3(screenBounds.x + 1, 
                                         screenBounds.y - (screenBounds.y * ((float)randomSpawnLocation/(float)(numberOfPotentialSpawns + 1)) * 2f),
                                         0f);

        newEnemy = Instantiate(enemy, enemySpawnPosition, Quaternion.identity);

        newEnemyMovementScript = newEnemy.GetComponent<EnemyMovement>();
        newEnemyMovementScript.prevScoreAtDifficultyIncrease = prevScoreAtDifficultyIncrease;

        enemySpriteRenderer = newEnemy.GetComponent<SpriteRenderer>();
        switch (Random.Range(0,2))
        {
            case 0:
                    newEnemy.tag = "Black";
                    enemySpriteRenderer.sprite = blackCircleWhiteBorder;
                    break;
            case 1: 
                    newEnemy.tag = "White";
                    enemySpriteRenderer.sprite = whiteCircleBlackBorder;
                    break;
        }
    }

    private void repeatingEnemySpawn()
    {
        int score = playerScoreScript.Score;
        if (score != 0 && score % increaseDifficultyOnLevel == 0 && score != prevScoreAtDifficultyIncrease)
        {
            prevScoreAtDifficultyIncrease = score;
            enemySpawnRate *= enemySpawnRateChange;
            //plug -(e^(3-.15x)-15) into graphing calculator to see speed increase curve
            enemySpeed = -(Mathf.Pow(E,3f-0.15f*enemySpeed) - maxEnemySpeed);
        }
        SpawnNewEnemy();
        Invoke("repeatingEnemySpawn",enemySpawnRate);
    }
}
