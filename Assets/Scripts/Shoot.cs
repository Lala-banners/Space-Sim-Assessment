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
            bullet.GetComponent<Rigidbody>().AddForce(transform.up * 10000);
            bullet.transform.position = BulletPool.pool.spawnLocation.transform.position;
            bullet.transform.rotation = BulletPool.pool.spawnLocation.transform.rotation;
            bullet.SetActive(true);
        }
    }
}
