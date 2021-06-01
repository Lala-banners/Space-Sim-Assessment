using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [Header("Health")]
    public Image healthBar;
    public float currentHealth;
    public float maximumHealth;
    public float smoothSpeed;
    private float regenSpeed;
    public GameObject healthContainer;

    // Start is called before the first frame update
    void Start() {
        currentHealth = maximumHealth;
        regenSpeed = 5f;
        healthContainer = healthBar.gameObject;
        healthContainer.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (currentHealth > maximumHealth)
            currentHealth = maximumHealth;

        smoothSpeed = 3f * Time.deltaTime;
        
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentHealth / maximumHealth, smoothSpeed);
        
        Regenerate();
        ChangeHealthColour();
    }

    public void Regenerate() {
        if (currentHealth <= maximumHealth / 25f)
        {
            currentHealth += regenSpeed * Time.deltaTime;
        }
    }

    public void ChangeHealthColour() {
        Color healthCol = Color.Lerp(Color.red, Color.yellow, (currentHealth / maximumHealth));
        healthBar.color = healthCol;
    }
}
