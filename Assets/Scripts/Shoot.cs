using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ShootBullet();
        }
    }

    public void ShootBullet()
    {
        GameObject bullet = BulletPool.pool.GetPooledObject("Bullet");
        if (bullet != null)
        {
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10000);
            bullet.transform.SetParent(BulletPool.pool.spawnLocation.transform);
            bullet.transform.rotation = BulletPool.pool.spawnLocation.transform.rotation;
            bullet.SetActive(true);
        }
    }
}
