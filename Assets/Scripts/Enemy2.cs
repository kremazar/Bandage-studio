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
    int MoveSpeed = 100;

    [SerializeField] private Animator en = null;


    //public float speed;
    //public float stoppingDistance;
    //public float retreatDistance;

    //private float timebtwshot;
    //public float startTimeBtwShots;
    //public GameObject[] projectile;

    public float waitTime = 0f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        stats.Init();
        //if (statusIndicator != null)
        //{
        //    statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        //}
        //timebtwshot = startTimeBtwShots;
        Player = GameObject.FindGameObjectWithTag("Player").transform;

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
        ChkEnemyDistRaiseDamage();
        ////Vector3 direction = player.position - transform.position;
        ////float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //////rb.rotation = angle;
        ////direction.Normalize();
        ////movement = direction;
        //transform.LookAt(Player);

        ////if (Vector3.Distance(transform.position, Player.position) >= 0)
        ////{

        ////    transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        ////    //if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        ////    //{
        ////    //    PlayerStats enemy = GetComponent<PlayerStats>();
        ////    //    if (enemy != null)
        ////    //    {
        ////    //        enemy.TakeDamage(damage);
        ////    //    }
        ////    //}

        ////}
        if (gameObject.name == "Bakterija2(Clone)")
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, 3 * Time.deltaTime);
        }
        //else
        //{
        //    if (Vector3.Distance(transform.position, Player.position) > stoppingDistance)
        //    {
        //        transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        //    }

        //    if (timebtwshot <= 0)
        //    {

        //        foreach (var item in projectile)
        //        {
        //            if (gameObject.name == "Bakterija4(Clone)")
        //            {
        //                Instantiate(projectile[0], transform.position, Quaternion.identity);
        //            }
        //            else if (gameObject.name == "Bakterija5(Clone)")
        //            {
        //                Instantiate(projectile[1], transform.position, Quaternion.identity);
        //            }
        //        }
        //        timebtwshot = startTimeBtwShots;
        //    }
        //    else
        //    {
        //        timebtwshot -= Time.deltaTime;
        //    }
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
            en.Play("AnimationDeath", 0, 0.0f);
            if (en.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5)
            {
                GameMaster.KillEnemy(this);
            }
            return;
        }
        en.Play("AnimationDamage", 0, 0.0f);
        //if (statusIndicator != null)
        //{
        //    statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        //}
    }
    void ChkEnemyDistRaiseDamage()
    {
        if (Vector3.Distance(transform.position, Player.position) <= 3)
        {
            if (Time.time - waitTime >= 3 && transform.parent.name.StartsWith("Hepatitis"))
            {
                stats.damage += 1;
                Debug.Log("Damage od enemija je porastao na " + stats.damage);
                waitTime = Time.time;
                Time.timeScale = 0.2f;
            }
        }

        else if (Vector3.Distance(transform.position, Player.position) >= 6 && !(GameObject.Find("Player/GUI/PauseGame").activeSelf))
        {
            Time.timeScale = 1.0f;
        }
    }
    void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.collider.name);
        Player _player = collision.collider.GetComponent<Player>();
        if (gameObject.name == "Bakterija2(Clone)")
        {
            _player.DamagePlayer(stats.damage);
            Destroy(gameObject, 0.5f);

        }
        if (_player != null)
        {
            en.Play("AnimationAttack", 0, 0.0f);
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
