using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    float spawnRate = 1;
    float timer;

    void Update()
    {
        transform.position = new Vector3(2, 4, Camera.main.transform.position.y + 40);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(_enemy, transform.position, Quaternion.identity, transform);
            timer = spawnRate;
        }
    }
}
