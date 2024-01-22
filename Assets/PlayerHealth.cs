using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public static int StartingHealth = 3;
    public int currentHealth = StartingHealth;
    public int maxHealth = 3;
    public HeartUI heartUI;

    void Start() {

        heartUI = FindObjectOfType<HeartUI>();
        heartUI.UpdateHeartsUI();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            currentHealth--;
            heartUI.UpdateHeartsUI();

            if (currentHealth <= 0) {
                //pass
            }
        }
    }
}
