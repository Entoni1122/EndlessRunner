using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerMVM : MonoBehaviour
{
    [SerializeField] float mvmSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityMultiplier = 1;
    float gravity = -9.81f;
    
    Vector3 Velocity;
    Vector3 direction;

    [SerializeField] CorridorManager CorridorManager;

    CharacterController _cc;
    [SerializeField] Animator _anim;

    [SerializeField]public bool jump => _anim.GetBool("Jump");
    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
    }
    void Update()
    {
        PlayerMove();
        if (transform.position.z > 50)
        {
            transform.position = Vector3.zero;
            CorridorManager.ResetCoordinateToZero();
        }
    }

    private void PlayerMove()
    {
        if (ISGROUNDED() && Velocity.y < 0)
        {
            Velocity.y = -1;
            _anim.SetBool("Jump", false);

        }

        float x = Input.GetAxis("Horizontal");
        if (transform.position.x >= 6 && x > 0 || transform.position.x <= -6 && x < 0)
        {
            x = 0;
        }
        direction.x = x;

        _anim.SetFloat("Blend",x);
        _cc.Move(direction * mvmSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && ISGROUNDED())
        {
            Velocity.y = jumpForce;
            _anim.SetBool("Jump", true);
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
