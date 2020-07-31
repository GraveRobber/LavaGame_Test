using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    BulletScriptableObject BulletData;
    public float Lifetime { get; set; }
    Rigidbody BulletRb;

    private void Start()
    {
        BulletRb = GetComponent<Rigidbody>();
    }
    public void Inst(BulletScriptableObject temp)
    {
        BulletData = temp;
        GetComponent<Renderer>().material.color = temp.MatColor;
    }

    public float Speed
    {
        get
        {
            return BulletData.Speed;
        }
    }

    public static Action<GameObject> DisableBullet;

    private void FixedUpdate()
    {
        if(Time.time > Lifetime && DisableBullet !=null)
        {
            DisableBullet(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            var temp = other.gameObject.GetComponentInParent<EnemyHandler>();
            if (temp != null)
            {
                temp.EnemyDeath();
            }
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(BulletRb.velocity) * BulletData.Force, ForceMode.Impulse);
            DisableBullet(this.gameObject);
        }
    }

}
