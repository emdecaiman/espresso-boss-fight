using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private float duration = 0.5f;

    Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        Physics2D.IgnoreLayerCollision(6, 7);
        Destroy(gameObject, duration);
    }
    
    // Start is called before the first frame update
    void Update() {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Boss")) {
            Destroy(gameObject);
        }
    }
}
