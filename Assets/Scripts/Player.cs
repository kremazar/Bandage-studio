using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth = 100;

        public HPBar healthBar;

        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }
        public void Init()
        {
            healthBar.SetMaxHealth(maxHealth);
            curHealth = maxHealth;
        }

        void TakeDamage(int damage) 
        {
            _curHealth -= damage;
            healthBar.SetHealth(_curHealth);
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(20);
            }
            //statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }
    }
    public PlayerStats stats = new PlayerStats();
    

    //[SerializeField]
    //private Status statusIndicator;

    void Start()
    {
        stats.Init();
        //if (statusIndicator == null)
        //{
        //    Debug.LogError("NO status indicator on player");
        //}
        //else
        //{
        //    statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        //}
    }
    void Update()
    {
        //statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
    }

    public void DamagePlayer(int damage)
    {
        Debug.Log("Hitas ga");
        stats.curHealth -= damage;
        if (stats.curHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }
        Debug.Log(stats.curHealth);
        //statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
    }
    //void oncollisionenter2d(collision2d collision)
    //{

    //    if (collision.gameobject.tag != "player")
    //    {
    //        if (collision.gameobject.name == "health(clone)")
    //        {
    //            stats.curhealth = stats.maxhealth;
    //            debug.log(stats.curhealth);
    //            destroy(collision.gameobject);
    //        }
    //        if (collision.gameobject.name == "ammo(clone)")
    //        {
    //            bullet.damage += 10;
    //            debug.log(bullet.damage);
    //            destroy(collision.gameobject);
    //        }
    //        if (collision.gameobject.name == "life(clone)")
    //        {
    //            gameover.lifes += 1;
    //            destroy(collision.gameobject);
    //        }
    //    }


    //}

}
