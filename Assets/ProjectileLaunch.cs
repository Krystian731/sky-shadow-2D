using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPiont;

    public float shootTime;
    public float shootCounter;
    void Start()
    {
        shootCounter = shootTime;
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && shootCounter <= 0)
        {
            Instantiate(projectilePrefab, launchPiont.position, Quaternion.identity);
            shootCounter = shootTime;
        }
        shootCounter -= Time.deltaTime;
    }
}
