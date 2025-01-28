using UnityEngine;

public class ThrowingBubbleProjectile : MonoBehaviour
{
    Vector3 direction = Vector3.left;
    
    [SerializeField] int damage = 5;

    float velocidad = 10;

    public void SetDirection(bool derecha)
    {
        if (derecha)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
            direction = Vector3.right;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
            direction = Vector3.left;
        }
    }


    bool hitDetected = false;
    private void Update()
    {
        transform.position += direction * velocidad * Time.deltaTime;

        if(Time.frameCount % 6 == 0)
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.7f);
            foreach (Collider2D c in hit)
            {
                Enemy enemy = c.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    hitDetected = true;
                    break;
                }
            }
            if (hitDetected == true)
            {
                Destroy(gameObject);
            }
        }        
    }
}
