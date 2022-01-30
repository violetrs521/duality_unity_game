using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    private GameObject newEnemy;
    public SpriteRenderer rend {get; set;}
    private Vector3 spawnPos;
    private int numSpawns;
    private int spawnNum;
    private float spawnSpeed;

    public Sprite whiteCircleBlackBorder;
    public Sprite blackCircleWhiteBorder;

    public Camera MainCamera;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        spawnSpeed = 1f;

        numSpawns = 8;

        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));

        InvokeRepeating("SpawnNewEnemy", 0f, spawnSpeed);
    }

    private void SpawnNewEnemy()
    {
        spawnNum = Random.Range(1,numSpawns + 1);
        spawnPos = new Vector3(screenBounds.x + 1, screenBounds.y - (screenBounds.y * ((float)spawnNum/(float)(numSpawns + 1)) * 2f), 0f);

        newEnemy = Instantiate(enemy, spawnPos, Quaternion.identity);
        rend = newEnemy.GetComponent<SpriteRenderer>();
        switch (Random.Range(0,2))
        {
            case 0:
                    newEnemy.tag = "Black";
                    rend.sprite = blackCircleWhiteBorder;
                    break;
            case 1: 
                    newEnemy.tag = "White";
                    rend.sprite = whiteCircleBlackBorder;
                    break;
        }
    }
}
