using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    private GameObject newEnemy;
    private SpriteRenderer rend;
    private Vector3 spawnPos, potentialSpawn1, potentialSpawn2, potentialSpawn3, potentialSpawn0;

    public Camera MainCamera;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));

        potentialSpawn0 = new Vector3(screenBounds.x + 1, screenBounds.y - (screenBounds.y * (1f/5f) * 2f), 0f);
        potentialSpawn1 = new Vector3(screenBounds.x + 1, screenBounds.y - (screenBounds.y * (2f/5f) * 2f), 0f);
        potentialSpawn2 = new Vector3(screenBounds.x + 1, screenBounds.y - (screenBounds.y * (3f/5f) * 2f), 0f);
        potentialSpawn3 = new Vector3(screenBounds.x + 1, screenBounds.y - (screenBounds.y * (4f/5f) * 2f), 0f);

        InvokeRepeating("SpawnNewEnemy", 0f, 2f);
    }

    private void SpawnNewEnemy()
    {
        switch (Random.Range(0,4))
        {
            case 0:
                    spawnPos = potentialSpawn0;
                    break;
            case 1:
                    spawnPos = potentialSpawn1;
                    break;
            case 2:
                    spawnPos = potentialSpawn2;
                    break;
            case 3:
                    spawnPos = potentialSpawn3;
                    break;
        }

        newEnemy = Instantiate(enemy, spawnPos, Quaternion.identity);
        rend = newEnemy.GetComponent<SpriteRenderer>();
        switch (Random.Range(0,2))
        {
            case 0:
                    rend.color = Color.black;
                    break;
            case 1: 
                    rend.color = Color.white;
                    break;
        }
    }
}
