using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMultiShooting : MonoBehaviour
{
     [Header("References")]
    //public Transform spawnPoint;

    public Transform [] spawnPoints;
    public GameObject projectilePrefab;

    [Header("Stats")]
    [Tooltip("Time, in seconds, between the firing of each projectile.")]
    public float fireRate = 1;
    private float lastFireTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastFireTime + fireRate)
            {
            lastFireTime = Time.time;
            
            /*
            Instantiate(projectilePrefab,spawnPoint.position,spawnPoint.
            rotation);
            */
            foreach(Transform spawnPoint in spawnPoints){
                var noviProjektil = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
                noviProjektil.transform.parent = spawnPoint.transform;
            }
            
            }
    }
}
