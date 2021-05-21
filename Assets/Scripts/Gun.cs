using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;

    public Camera camera;
    public GameObject bullet;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            if (hit.transform.tag != "Player")
            {
                Debug.Log(hit.transform.name);
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
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
