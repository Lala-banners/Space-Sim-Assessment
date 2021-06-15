using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public EnemyStats _enemyStats;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
    }

    private void Update() {
        _enemyStats = FindObjectOfType<EnemyStats>();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Enemy"))
        {
            Debug.Log("Enemy is taking damage");
            
            if (_enemyStats.currentHealth <= 0)
            {
                _enemyStats.Die();
                WinManager.instance.WinGame();
                Debug.Log("Enemy is dead");
            }
        }
    }
}
