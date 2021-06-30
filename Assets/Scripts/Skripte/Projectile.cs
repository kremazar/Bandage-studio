using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("References")]
    public Transform trans;
    [Header("Stats")]
    [Tooltip("How many units the projectile will move forward per second.")]
    public float speed = 34;

    [Tooltip("The distance the projectile will travel before it comes to a stop.")]
    public float range = 5;

    private Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = trans.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Move the projectile along its local Z axis (forward):
        trans.Translate(0, 0, speed * Time.deltaTime, Space.Self);

        //Destroy the projectile if it has traveled to or past its range:
        if(Vector3.Distance(trans.position, spawnPoint) >= range){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
        Player player = other.GetComponent<Player>();

        if(player != null){
            player.DamagePlayer(30);
        }
        }
    }
}
