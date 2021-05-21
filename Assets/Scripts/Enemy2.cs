using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public Transform Player;
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector2 movement;
    GameObject search;
    int MoveSpeed = 10;



    //[SerializeField]
    //private Status statusIndicator;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        stats.Init();
        //if (statusIndicator != null)
        //{
        //    statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        //}
    }
    void Update()
    {

        if (Player == null)
        {
            search = GameObject.FindGameObjectWithTag("Player");
            if (search != null)
            {
                Player = search.transform;
            }
        }
        //Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        ////rb.rotation = angle;
        //direction.Normalize();
        //movement = direction;
        transform.LookAt(Player);

        //if (Vector3.Distance(transform.position, Player.position) >= 0)
        //{

        //    transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        //    //if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        //    //{
        //    //    PlayerStats enemy = GetComponent<PlayerStats>();
        //    //    if (enemy != null)
        //    //    {
        //    //        enemy.TakeDamage(damage);
        //    //    }
        //    //}

        //}
    }


    [System.Serializable]
    public class EnemyStats
    {
        public int maxHealth = 100;

        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }
        public int damage = 20;
        public void Init()
        {
            curHealth = maxHealth;
        }
    }
    public EnemyStats stats = new EnemyStats();



    public void DamageEnemy(int damage)
    {
        stats.curHealth -= damage;
        if (stats.curHealth <= 0)
        {
            GameMaster.KillEnemy(this);
        }
        //if (statusIndicator != null)
        //{
        //    statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        //}
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        Player _player = collision.collider.GetComponent<Player>();

        if (_player != null)
        {
            _player.DamagePlayer(stats.damage);
        }
        //if (collision.gameObject.tag == "Help")
        //{
        //    Destroy(collision.gameObject);
        //}
        //if (collision.gameObject.tag == "Wall")
        //{
        //    Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //}

    }


}
