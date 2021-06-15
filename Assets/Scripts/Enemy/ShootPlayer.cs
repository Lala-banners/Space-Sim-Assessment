using System.Collections;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [Header("Shooting")] 
    public GameObject rocket;
    public Transform firePoint;
    public Spaceship player;
    private float distance;
    
    // Start is called before the first frame update
    void Start() {
        player = FindObjectOfType<Spaceship>();
    }

    // Update is called once per frame
    void Update() {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < 500)
        {
            StartCoroutine(ShootShip());
        }
        
        Debug.DrawRay(firePoint.position, -transform.up * Mathf.Infinity, Color.red);
        
        if (Physics.Raycast(firePoint.position, -transform.up, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("You are Hit!");
            }
        }
    }

    private IEnumerator ShootShip() {
        rocket = SpacePool.pool.GetPooledObject("Rocket");
        if (rocket != null)
        {
            rocket.transform.SetParent(SpacePool.pool.spawnLocation.transform);
            rocket.transform.rotation = SpacePool.pool.spawnLocation.transform.rotation;
            rocket.SetActive(true);
        }

        yield return new WaitForSeconds(2);
    }
}
