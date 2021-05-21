using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] Spawnpoint;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Spawn()
    {
            foreach (var item in enemy)
            {
                foreach (var spawn in Spawnpoint)
                {
                    Instantiate(item, spawn.transform.position, Quaternion.identity);
                }   
            }  
            yield return new WaitForSeconds(1f);
    }
}
