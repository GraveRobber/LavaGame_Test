using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bulletPref;
    public List<BulletScriptableObject> BulletData;
    public Transform BulletPool;

    public int SetForse { get; set; }
    
    [SerializeField]
    float PoolCount;

    [SerializeField]
    float Cooldown;

    float temp;
    Transform InstPoint;

    public static Dictionary<GameObject, Bullet> Bullets;
    Queue<GameObject> currBullet;

    private void Start()
    {
        Bullets = new Dictionary<GameObject, Bullet>();
        currBullet = new Queue<GameObject>();
        InstPoint = this.gameObject.GetComponent<PlayerHandler>().FireObj.transform;

        for (int i = 0; i < PoolCount; i++)
        {
            GameObject bullet = Instantiate(bulletPref, InstPoint.position, Quaternion.identity, BulletPool);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bullet.SetActive(false);
            Bullets.Add(bullet, bulletScript);
            currBullet.Enqueue(bullet);
        }

        Bullet.DisableBullet += ReturnBullet;
    }

    private void ReturnBullet(GameObject temp)
    {
        temp.transform.position = InstPoint.position;
        temp.SetActive(false);
        currBullet.Enqueue(temp);
    }

    public void Shoting(Vector3 dir)
    {
        if (temp < Time.time)
        {
            GameObject bullet = currBullet.Dequeue();
            Bullet script = Bullets[bullet];
            script.Inst(BulletData[SetForse]);
            bullet.transform.position = InstPoint.position;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(dir) * script.Speed;
            script.Lifetime = Time.time + Cooldown * 2;
            temp = Time.time + Cooldown;
        }
        

    }

}
