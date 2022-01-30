using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    private GameObject newEnemy;
    private SpriteRenderer rend;
    private int randomSpawnZone;
    private float randomX, randomY;
    private Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNewEnemy", 0f, 2f);
    }

    private void SpawnNewEnemy()
    {
        randomSpawnZone = Random.Range(0,4);

        switch (randomSpawnZone)
        {
            case 0:
                    randomX = Random.Range(-11f, -10f);
                    randomY = Random.Range(-10f, 10f);
                    break;
            case 1:
                    randomX = Random.Range(-10f, 10f);
                    randomY = Random.Range(-7f, -8f);
                    break;
            case 2:
                    randomX = Random.Range(10f, 11f);
                    randomY = Random.Range(-8f, 8f);
                    break;
            case 3:
                    randomX = Random.Range(-10f, 10f);
                    randomY = Random.Range(7f, 8f);
                    break;
        }

        spawnPos = new Vector3(randomX, randomY, 0f);
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
