using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float cameraSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,_target.position,cameraSpeed * Time.deltaTime);
    }




}
