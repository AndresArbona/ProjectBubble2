using UnityEngine;

public class Enemy : MonoBehaviour
{
    //VARS
    GameObject targetGameObject;
    PlayerCharacter character;

    Transform targetDestination;
    [SerializeField] float speed;
    [SerializeField] float health;
    [SerializeField] int damage;
    [SerializeField] int experienceReward = 10;

    Rigidbody2D rgbd2d;

    //FUNCTIONS

    private  void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        if (targetDestination != null)
        {
            Vector3 direction = (targetDestination.position - transform.position).normalized;
            transform.position += direction * speed  * Time.fixedDeltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack(); 
        }
    }

    private void Attack()
    {
        if (character == null)
        {
            character = targetGameObject.GetComponent<PlayerCharacter>();
        }

        character.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 1)
        {
            targetGameObject.GetComponent<Level>().AddExperience(experienceReward);
            Destroy(gameObject);
        }
    }


    private void Die()
    {
        Debug.Log("Enemy assesinated");
        Destroy(gameObject);
    }
}
