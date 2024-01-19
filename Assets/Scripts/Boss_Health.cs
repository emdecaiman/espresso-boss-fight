using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int maxHealth = 10000;
    [SerializeField] private int currentHealth;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    private void Update() {
    
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;

        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
    

}
