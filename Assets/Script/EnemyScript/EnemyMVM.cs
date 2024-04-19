using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMVM : MonoBehaviour
{
    [SerializeField] GameObject _onDeadParticle;
    public float maxHP;
    float currentHP;
    private void Start()
    {
        currentHP = maxHP;
    }
    private void OnEnable()
    {
        currentHP = maxHP;
    }
    void Update()
    {
        transform.Translate(new Vector3(0, 0, GlobalVariables.enemySpeed) * Time.deltaTime);
    }

    public void OnDMGTaken(float dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
        {
            OnDEAD();
        }
    }

    private void OnDEAD()
    {
        Instantiate(_onDeadParticle,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
