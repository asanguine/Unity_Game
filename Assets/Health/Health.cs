using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private void Awake() {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage) {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth <= 0) {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }

    
    public void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("took damage");
            Debug.Log(currentHealth);
            TakeDamage(1);
        }
    }
}
