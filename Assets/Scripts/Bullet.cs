using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static int damage = 10;
    GameObject target;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        target = GameObject.FindWithTag("Player");
        if (other.gameObject.tag != target.tag && other.gameObject.tag != "Help")
        {
            Enemy2 enemy = other.GetComponent<Enemy2>();
            if (enemy != null)
            {
                enemy.DamageEnemy(damage);
            }
            Destroy(gameObject);
        }
    }
}
