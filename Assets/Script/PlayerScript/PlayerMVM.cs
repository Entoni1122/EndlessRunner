using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMVM : MonoBehaviour
{
    [SerializeField] float mvmSpeed;

    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");

        if (transform.position.x >= 6 && x > 0 || transform.position.x <= -6 && x < 0)
        {
            x = 0;
        }
        Vector3 dir = new Vector3(x  * mvmSpeed, 0);
        transform.Translate(dir * Time.deltaTime);
    }
}
