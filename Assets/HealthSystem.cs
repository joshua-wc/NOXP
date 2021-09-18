using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthSystem : MonoBehaviour
{
    [FormerlySerializedAs("health")]
    public float maxHealth;

    float currentHealth;

    public GameObject healthBarPrefab;

    public GameObject deathEffectPrefab;

    HealthBarBehaviour myHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        GameObject healthBarObject = Instantiate(healthBarPrefab, References.canvas.transform);
        myHealthBar = healthBarObject.GetComponent<HealthBarBehaviour>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        

        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                if (deathEffectPrefab != null)
                {
                    Instantiate(deathEffectPrefab, transform.position, transform.rotation);
                }

                Destroy(gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        if (myHealthBar != null) 
        {
            Destroy(myHealthBar.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        myHealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);

        // make our healthbar follow us

        myHealthBar.ShowHealthFraction(currentHealth / maxHealth);

        //make healthbar show health



    }
}
