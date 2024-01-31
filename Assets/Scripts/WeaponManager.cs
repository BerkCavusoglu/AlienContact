using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int minDamage, maxDamage;
    public Camera playerCamera;
    public float range = 300f;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    private EnemyManager enemyManager;
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
            muzzleFlash.Play();
        }
    }
    void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            enemyManager = hit.transform.GetComponent<EnemyManager>();
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            if (enemyManager != null)
            {
                enemyManager.EnemyTakeDamage(Random.Range(minDamage, maxDamage));
            }
            
        }
    }
}
