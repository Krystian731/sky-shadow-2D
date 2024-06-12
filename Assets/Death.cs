using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deat : MonoBehaviour
{
    public Vector3 spawnPoint;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player") 
        {
            other.transform.position = spawnPoint;
        }
    }
}
