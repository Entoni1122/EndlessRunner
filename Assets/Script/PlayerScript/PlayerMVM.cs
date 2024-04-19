using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMVM : MonoBehaviour
{
    [SerializeField] float mvmSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityMultiplier = 1;
    [SerializeField]private Vector3 Velocity;

    float gravity = -9.81f;
    CharacterController _cc;
    Vector3 direction;

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
    }
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (ISGROUNDED() && Velocity.y < 0)
        {
            Velocity.y = -1;
        }

        float x = Input.GetAxis("Horizontal");

        if (transform.position.x >= 6 && x > 0 || transform.position.x <= -6 && x < 0)
        {
            x = 0;
        }
        direction.x = x;
        _cc.Move(direction * mvmSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && ISGROUNDED())
        {
            Velocity.y = jumpForce;
        }

        Velocity.y += gravity * gravityMultiplier * Time.deltaTime;

        _cc.Move(Velocity * Time.deltaTime);
    }
    bool ISGROUNDED()
    {
        if (Physics.Raycast(transform.position,Vector3.down,0.2f))
        {
            return true;
        }
        return false;
    }
}
