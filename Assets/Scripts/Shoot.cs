using UnityEngine;
using TMPro;
public class Shoot : MonoBehaviour
{
    [Header("Shooting")] 
    public GameObject bullet;
    public int ammunition;
    private int maxAmmo = 20;
    public TMP_Text ammoText;

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Ammo: " + ammunition;
    
        if (ammunition <= 0)
        {
            ammunition = 0;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload(maxAmmo);

            if (ammunition >= maxAmmo)
            {
                ammunition = maxAmmo;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            ShootBullet();
            DecreaseAmmo(1);
        }
    }
    #region Shoot
    
    public void ShootBullet()
    {
        bullet = SpacePool.pool.GetPooledObject("Bullet");
        if (bullet != null)
        {
            bullet.transform.SetParent(SpacePool.pool.spawnLocation.transform);
            bullet.transform.rotation = SpacePool.pool.spawnLocation.transform.rotation;
            bullet.SetActive(true);
        }
        
        Debug.DrawRay(bullet.transform.position, Vector3.forward, Color.green);
        if (Physics.Raycast(bullet.transform.position, Vector3.forward, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Enemy Hit!");
            }
        }
    }
    
    public void DecreaseAmmo(int decreaseAmount) {
        ammunition -= decreaseAmount;
    }

    public void Reload(int increaseAmount) {
        ammunition += increaseAmount;
    }
    #endregion
}
