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

    public float m_MaxDistance;

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
        if (firePoint.gameObject.activeInHierarchy == true)
        {
            int layerMask = 1 << 8;
            layerMask = ~layerMask;
            RaycastHit hit;
            Vector3 direction = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range, layerMask, QueryTriggerInteraction.Ignore))
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
                audioData.Play();
            }
        }
    }
}
