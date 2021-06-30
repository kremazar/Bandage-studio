using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleProjectiles : MonoBehaviour
{
   [Header("References")]
    public Transform trans;
    [Header("Stats")]
    [Tooltip("How many units the projectile will move forward per second.")]
    public float speed = 34;

    [Tooltip("The distance the projectile will travel before it comes to a stop.")]
    public float range = 20;

    private Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = trans.position;
    }

    // Update is called once per frame
    void Update()
    {       

        string parentName = transform.parent.name;
        //Check spawn shoot position
        switch(parentName){
            case "SpawnPoint": 
                trans.Translate(0,0,speed * Time.deltaTime, Space.Self);
                break;
            case "SpawnPoint Behind":
                trans.Translate(0, 0, -1 * speed * Time.deltaTime, Space.Self);
                break;
            case "SpawnPoint Left":
                trans.Translate(-1 * speed * Time.deltaTime,0, 0,Space.Self);
                break;
            case "SpawnPoint Right":
                trans.Translate(speed * Time.deltaTime,0, 0,Space.Self);
                break;
        }
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
