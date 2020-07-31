using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public List<Rigidbody> RagdollRigidbody = new List<Rigidbody>();
    Animator EnemyAnim;
    Collider BodyCollider;
    public bool isDead { get; set; }

    float temp;

    public void Awake()
    {
        EnemyAnim = GetComponent<Animator>();
        foreach (Rigidbody rb in RagdollRigidbody)
        {
            rb.isKinematic = true;
        }

    }

    private void Update()
    {
        if(/*Time.timeScale != 1 && */temp < Time.time)
        {
            print(Time.timeScale);
            Time.timeScale = 1;
            print(Time.timeScale);
        }
    }

    public void EnemyDeath()
    {
        EnemyAnim.enabled = false;
        foreach (Rigidbody rb in RagdollRigidbody)
        {
            rb.isKinematic = false;
        }

        temp = Time.time + 0.6f;
        Time.timeScale = 0.3f;
        
        print("Time = " + Time.time);
        print("and temp = " + temp);
        isDead = true;
    }

}
