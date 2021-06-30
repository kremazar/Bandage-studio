using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mojProjektil : MonoBehaviour
{
    public float speed;
    private Transform Player;
    private Vector3 target;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(Player.position.x, Player.position.y, Player.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,target,speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            Destroy(gameObject);
        }

    }
   
    private void OnTriggerEnter(Collider other)
    {
        Player _player = other.GetComponent<Player>();

        if (_player != null)
        {
            _player.DamagePlayer(30);
            Destroy(gameObject);
        }

    }
}
