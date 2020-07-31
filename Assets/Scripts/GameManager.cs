using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public Transform Spawn;
    public GameObject ZombiePref;
    GameObject currEnemy;
    private void Start()
    {
        InstEnemy();
    }

    public void InstEnemy()
    {
        if(currEnemy == null || currEnemy.GetComponent<EnemyHandler>().isDead)
        {
            currEnemy = Instantiate(ZombiePref, Spawn.position, Quaternion.identity, Spawn.transform);
            currEnemy.GetComponent<EnemyHandler>().isDead = false;
        }
        
    }

    public void Clear()
    {
        for(int i = 0; i<Spawn.childCount; i++)
        {
            Destroy(Spawn.GetChild(i).gameObject);
        }
    }

    
}
