using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    //VARIABLES

    [SerializeField]private  int maxHealth = 1000;
    public int currentHealth;

    [HideInInspector] public Level level;

    //FUNCTIONS

    private void Awake()
    {
        currentHealth = maxHealth;
        level = GetComponent<Level>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{damage} taken, current health: {currentHealth}");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Defeat");
        }
    }
}
