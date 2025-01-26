using UnityEngine;

public class Animate : MonoBehaviour
{
    
    Animator anim;

    public float horizontal;
    public float Vertical;


    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        AnimatePlayer();
    }

    private void AnimatePlayer()
    {
        anim.SetFloat("HorizontalMovement", horizontal);
        anim.SetFloat("VerticalMovement", Vertical);
    }
}
