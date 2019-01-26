using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private GameControlScript gameControl;

    [SerializeField] private int maxHealth = 10;
    private int health;

    void Start() {
        gameControl = GameControlScript.instance;
        health = maxHealth;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Bullet")) {
            print("Hit!");
            health--;
            if (health <= 0) {
                Die();
            }
        }
    }

    private void Die() {
        // TODO disable and reset this.
        Reset();
        gameControl.ExitBossMode();
    }

    public void Activate() {
        transform.root.gameObject.SetActive(true);
    }

    public void Reset() {
        transform.root.gameObject.SetActive(false);
        health = maxHealth;
        // TODO reset postion
    }
}
