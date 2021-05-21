using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy = null;
    public int xPos;
    public int zPos;
    public int enemyCount;
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
        while (enemyCount < 10)
        {
            xPos = Random.Range(-37, 33);
            zPos = Random.Range(-22, 22);
            Instantiate(enemy, new Vector3(xPos, 3, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount++;
        }
    }
}
