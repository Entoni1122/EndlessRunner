using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMVM : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(0, 0, GlobalVariables.enemySpeed) * Time.deltaTime);
    }

}
