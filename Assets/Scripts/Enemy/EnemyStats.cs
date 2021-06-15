using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [Header("Health")]
    public Image healthBar;
    public float currentHealth;
    private float maximumHealth = 100f;
    public float smoothSpeed;
    public GameObject healthContainer;

    // Start is called before the first frame update
    void Start() {
        currentHealth = maximumHealth;
        healthContainer = healthBar.gameObject;
        healthContainer.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        if (currentHealth > maximumHealth)
            currentHealth = maximumHealth;

        smoothSpeed = 3f * Time.deltaTime;
        
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentHealth / maximumHealth, smoothSpeed);
        
        ChangeHealthColour();
    }

    public void ChangeHealthColour() {
        Color healthCol = Color.Lerp(Color.red, Color.yellow, (currentHealth / maximumHealth));
        healthBar.color = healthCol;
    }

    public void Die() {
        if (currentHealth <= 0)
        {
            WinManager.instance.WinGame();
            Destroy(gameObject);
        }
    }
    
    public void TakeDamage(float _damage) {
        if (currentHealth > 0)
        {
            currentHealth -= _damage;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            TakeDamage(10);
        }
    }
}
