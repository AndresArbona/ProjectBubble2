using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerCharacter : MonoBehaviour
{
    //VARIABLES

    private Rigidbody2D Rigidbody2D;
    private Animator anim;
    private Vector2 MovementInputVector;


    [SerializeField] float maxLife = 0.0f;
    [SerializeField] float maxExperience = 0.0f;
    [SerializeField] float MovementSpeed = 0.0f;
    [SerializeField] float attackSpeed = 0.0f;
    [SerializeField] float maxRadeoCollection = 0.0f;

    [SerializeField]float damage = 20.0f;

    public float experienceModifier = 1.0f;
    public float speedModifier = 1.25f;
    public float attackModifier = 1.0f;
    public float RadeoModifier = 1.0f;
    public float damageModifier = 1.0f;

    float currentLife = 0.0f;
    float currentExperience = 0.0f;
    float currentRadeoCollection;


    //FUNCTIONS

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        maxLife = 100.0f;
        maxExperience = 100.0f;
        MovementSpeed = 20.0f;
        MovementSpeed = 0.0f;
        attackSpeed = 2.0f;
        maxRadeoCollection = 50.0f;
        damage = 30.0f;

        currentLife = maxLife;
        currentRadeoCollection = maxRadeoCollection;
    }


    void Update()
    {
        Move();
        AnimatePlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            recibirDanio(damage);
        }

    }

    private void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        if(Horizontal == 0 && Vertical == 0)
        {
            Rigidbody2D.linearVelocity = new Vector2(0, 0);
            return;
        }

        MovementInputVector = new Vector2(Horizontal, Vertical);
        Rigidbody2D.linearVelocity = MovementInputVector * (MovementSpeed * speedModifier) * Time.fixedDeltaTime;
    }
    private void AnimatePlayer() {

        anim.SetFloat("HorizontalMovement", MovementInputVector.x);
        anim.SetFloat("VerticalMovement", MovementInputVector.y);
    }

    private void RecogerExperiencia(float experienceCollected)
    {
        currentExperience += experienceCollected * experienceModifier;

        if (currentExperience >= maxExperience) { 
        
            LevelUp();
        }
    }
    private void LevelUp()
    {
        //Mejoras();
    }

    private void Atacar()
    {
        //TODO: AutoAttack
    }


    public void recibirDanio(float danio)
    {
        currentLife = (currentLife - danio);
        currentLife = Mathf.Clamp(currentLife, 0, maxLife);

        Debug.Log($"recibió {damage} de daño. Salud restante: {currentLife}");

        if (currentLife <= 0)
        {
            Morir();
        }
    }
    private void Morir()
    {
        Debug.Log("Has Muerto");

        anim.SetBool("Muerto", true);

        //TODO: Make sound  and call Defeat UI
        Destroy(this);
    }

}
