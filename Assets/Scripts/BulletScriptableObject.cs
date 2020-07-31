using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName ="Bullet_test", order = 1)]
public class BulletScriptableObject : ScriptableObject
{
    
    [SerializeField]
    private float speed;
    public float Speed
    {
        get
        {
            return speed;
        }
    }

    [SerializeField]
    private float force;
    public float Force
    {
        get
        {
            return force;
        }
    }

    [SerializeField]
    private Color matColor;
    public Color MatColor
    {
        get
        {
            return matColor;
        }
    }

}
