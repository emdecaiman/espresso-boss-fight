using System;
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


    private void Awake() {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update() {
        // Keep track of the time since ability was last used
        // then compare it to the cooldown duration
        if (Input.GetKeyDown(KeyCode.X) && Time.time > lastUsedTime + cooldownTime) {
            StartCoroutine(FireProjectile());
            lastUsedTime = Time.time;
        }
        
    }

    private IEnumerator FireProjectile() {
        Debug.Log("Input: Attack");
        player.isAttacking = true;
        for (int i = 0; i < 3; i++) {
                Instantiate(projectile, firePosition.position, firePosition.rotation);
                yield return new WaitForSeconds(.1f);
            }
        player.isAttacking = false;
    }
}
