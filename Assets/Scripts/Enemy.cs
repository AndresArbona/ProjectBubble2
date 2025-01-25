using UnityEngine;

public class Enemy : MonoBehaviour
{
    //VARS

    [SerializeField] private float MaxLife;
    [SerializeField] private float Damage;
    [SerializeField] private float MovementSpeed;

    private Transform PlayerPosition;


    float damageModifier = 1.5f;
    float speedModifier = 1.25f;
    float lifeModifier = 2.0f;

    //FUNCTIONS


    private  void Awake()
    {

        MaxLife = 100.0f;
        Damage = 20.0f;
        MovementSpeed = 2.0f;
    }

    private void Start()
    {
        GameObject PlayerObj = GameObject.FindGameObjectWithTag("Player");

        if (PlayerObj != null) 
        {
            PlayerPosition = PlayerObj.transform;
        }
    }

    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        if (PlayerPosition != null)
        {
            Vector3 direction = (PlayerPosition.position - transform.position).normalized;
            transform.position += direction * (MovementSpeed * speedModifier) * Time.fixedDeltaTime;
        }
    }

    private void AnimateEnemy()
    {

    }

    private void Die()
    {

        Debug.Log("Enemy assesinated");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCharacter player = collision.gameObject.GetComponent<PlayerCharacter>();
            if (player != null)
            {
                Debug.Log("touching");

                player.recibirDanio(Damage);
            }
        }
    }

}
