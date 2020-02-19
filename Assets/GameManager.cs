using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public int enemyCount = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject newPlayer = Instantiate(player, getRandomPos(), Quaternion.identity) as GameObject;
        
        for (int i = 0; i < enemyCount; i++) {
            GameObject newEnemy = Instantiate(enemy, getRandomPos(), Quaternion.identity) as GameObject;
        }
    }

    Vector3 getRandomPos() {
        float spawnPosX = Random.Range(-8f, 8f);
        float spawnPosY = Random.Range(-2f, 2f);

        return new Vector3(spawnPosX, spawnPosY);
    }
}
