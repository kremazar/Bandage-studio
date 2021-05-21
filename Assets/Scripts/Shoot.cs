using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Shoot : MonoBehaviour
{
    public int damage = 10;
    public Transform firePoint;
    public float range = 100f;
    public AudioSource audioData;
    public Camera camera;
    public GameObject bullet;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shooot();

        }
    }
    void Shooot()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            if (hit.transform.tag != "Player")
            {
                Debug.Log(hit.transform.name);
                Enemy2 enemy = hit.transform.GetComponent<Enemy2>();
                if (enemy != null)
                {
                    enemy.DamageEnemy(damage);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(hit.normal);
                }
                GameObject Bullet = Instantiate(bullet, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(Bullet, 0.1f);
            }
        }
    }
}
