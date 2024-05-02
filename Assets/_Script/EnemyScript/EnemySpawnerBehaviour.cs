using UnityEngine;
using Unity.Burst;

[BurstCompile]
public class EnemySpawnerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    [SerializeField] float spawnRate = 1;
    float timer;

    void Update()
    {
        transform.position = new Vector3(0, 3, Camera.main.transform.position.z + 40);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            float randomX = Random.Range(-8,8);
            float randomY = Random.Range(-2,2);

            Vector3 enmeyPos = new Vector3 (randomX, randomY, 0);

            enmeyPos += transform.position;

            Instantiate(_enemy, enmeyPos, Quaternion.identity, transform);
            timer = spawnRate;
        }
    }
}
