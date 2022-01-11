using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 20;
    [SerializeField] int currentHealth = 20;

    Enemy enemy;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            enemy.RewardGold();
            gameObject.SetActive(false);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(other.gameObject.GetComponent<Bolt>().BoltDamage());

    }
}
