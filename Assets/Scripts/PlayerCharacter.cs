using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerCharacter : MonoBehaviour
{
    //VARIABLES

    private Rigidbody2D rigidbody2D;
    private Animator anim;
    private Vector2 MovementInputVector;

    [SerializeField] float vidaMaxima = 0.0f;
    [SerializeField] float experiencia = 0.0f;
    [SerializeField] float velocidadMovimiento = 0.0f;
    [SerializeField] float velocidadAtaque = 0.0f;
    [SerializeField] float radeoRecoleccion = 0.0f;

    float vidaActual = 0.0f;

    //FUNCTIONS

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        Move();
        AnimatePlayer();
    }

    private void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        if(Horizontal == 0 && Vertical == 0)
        {
            rigidbody2D.linearVelocity = new Vector2(0, 0);
            return;
        }

        MovementInputVector = new Vector2(Horizontal, Vertical);
        rigidbody2D.linearVelocity = MovementInputVector * velocidadMovimiento * Time.fixedDeltaTime;
    }

    private void AnimatePlayer() {

        anim.SetFloat("HorizontalMovement", MovementInputVector.x);
        anim.SetFloat("VerticalMovement", MovementInputVector.x);
    }


    private void Atacar()
    {

    }

    private void Morir()
    {

    }

    private void recibirDanio(float danio)
    {
        vidaActual = (vidaActual - danio);

        if (vidaActual < 0)
        {
            Morir();
        }
    }
        
}
