using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    //VARIABLES

    [SerializeField] public  float maxHealth = 10000;
    public float currentHealth;
    [SerializeField] private LifeBar LifeBar;
    [SerializeField] private GameManager GameManager;

    [HideInInspector] public Level level;

    //FUNCTIONS

    private void Awake()
    {
        currentHealth = maxHealth;
        LifeBar.ReadyHealthBar();
        level = GetComponent<Level>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        LifeBar.ChangeLifeAct();
        Debug.Log($"{damage} taken, current health: {currentHealth}");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Defeat");
        }
    }
}
