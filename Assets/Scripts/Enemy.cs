using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    public Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 5;

    [SerializeField]private Animator en = null;

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            //if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            //{
            //    PlayerStats enemy = GetComponent<PlayerStats>();
            //    if (enemy != null)
            //    {
            //        enemy.TakeDamage(damage);
            //    }
            //}
            PlayerStats enemy = GetComponent<PlayerStats>();
            enemy.TakeDamage(damage);
            Debug.Log("enemy attack");

        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
