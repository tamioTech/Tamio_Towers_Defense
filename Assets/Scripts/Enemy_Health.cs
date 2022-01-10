using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    [SerializeField] int health = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {

        }
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(other.gameObject.GetComponent<Bolt>().BoltDamage());

    }
}
