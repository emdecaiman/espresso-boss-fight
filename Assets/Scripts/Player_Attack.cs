using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform firePosition;
    [SerializeField] private GameObject projectile;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private float cooldownTime = 0.5f;
    private float lastUsedTime;


    void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update() {
        // Keep track of the time since ability was last used
        // then compare it to the cooldown duration
        if (Input.GetKeyDown(KeyCode.X) && Time.time > lastUsedTime + cooldownTime) {
            
            StartCoroutine(fireProjectile());
            lastUsedTime = Time.time;
        }
        
    }

    IEnumerator fireProjectile() {
        player.canMove = false;
        for (int i = 0; i < 3; i++) {
                Instantiate(projectile, firePosition.position, firePosition.rotation);
                yield return new WaitForSeconds(.1f);
            }
        player.canMove = true;
    }
}
