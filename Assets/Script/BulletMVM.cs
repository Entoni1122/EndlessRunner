using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMVM : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 direction;
    private void Start()
    {
        Destroy(gameObject,5);
    }
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    public void Init(Vector3 dir)
    {
        direction = dir;
    }
}
