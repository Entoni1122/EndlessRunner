using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Particlehandler : MonoBehaviour 
{
    private void OnParticleSystemStopped()
    {
        Destroy(this.gameObject);
    }
}
