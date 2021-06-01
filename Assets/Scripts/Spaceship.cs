using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpaceshipPhysics))]
[RequireComponent(typeof(SpaceshipInput))]
public class Spaceship : MonoBehaviour
{
    [Header("Ship Stats")] 
    public bool isPlayer = false;
    public Transform beacon;
    public TMP_Text distanceText;
    public Transform enemySpawn;
    public bool shouldEnemySpawn = false;

    [Header("Health")] 
    public float currentHealth = 100;
    public float maximumHealth = 100;
    public Image healthRing;
    public float smoothSpeed;

    #region Properties
    
    private SpaceshipInput _input;
    private SpaceshipPhysics _physics;

    public static Spaceship PlayerShip {
        get { return playerShip; }
    }

    private static Spaceship playerShip;

    public bool UsingMouseInput {
        get { return _input.useMouseInput; }
    }

    public Vector3 Velocity {
        get { return _physics.Rigidbody.velocity; }
    }

    public float Throttle {
        get { return _input.throttle; }
    }
    #endregion
    
    private void Awake() {
        _input = GetComponent<SpaceshipInput>();
        _physics = GetComponent<SpaceshipPhysics>();
        currentHealth = maximumHealth;
    }

    private void Update() {
        //Distance between ship and the beacon
        PlanetPosition();

        //Player Health
        UpdateHealth();
    }


    private void FixedUpdate() {
        _physics.SetPhysicsInput(new Vector3(_input.strafe, 0.0f, _input.throttle),
            new Vector3(_input.pitch, _input.yaw, _input.roll));

        if (isPlayer)
        {
            playerShip = this;
        }
    }

    #region Positions

    public void PlanetPosition() {
        if (beacon)
        {
            float distance = Vector3.Distance(beacon.position, transform.position);
            distanceText.text = "Distance To Planet Beacon: " + distance;
            shouldEnemySpawn = false;

            if (distance < 10f)
            {
                shouldEnemySpawn = true;
                SpawnEnemy();
            }
        }
    }

    #endregion
    
    
    #region Health

    public void UpdateHealth() {
        if (currentHealth > maximumHealth) currentHealth = maximumHealth;
        smoothSpeed = 3f * Time.deltaTime; //To smooth transition from one colour to another
        Health();
        HealthRingColourChange();
    }
    
    public void Health() {
        healthRing.fillAmount = Mathf.Lerp(healthRing.fillAmount, currentHealth / maximumHealth, smoothSpeed);
    }

    public void HealthRingColourChange() {
        Color healthCol = Color.Lerp(Color.red, Color.green, (currentHealth / maximumHealth));
        healthRing.color = healthCol;
    }

    public void Dead() {
        if (currentHealth <= 0)
        {
            print("Player is dead");
        }
    }

    public void TakeDamage(float _damage) {
        if (currentHealth > 0) currentHealth -= _damage;
    }

    #endregion

    #region Spawn Enemy Ship

    public void SpawnEnemy() {
        GameObject enemyShip = SpacePool.pool.GetPooledObject("Enemy");

        if (enemyShip != null)
        {
            enemyShip.transform.position = enemySpawn.position;
            enemyShip.SetActive(true);
        }
    }

    #endregion
}