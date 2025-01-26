using UnityEngine;

public class ThrowBubblesWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    float timer;

    PlayerMovement playerMovement;

    [SerializeField] GameObject BubblePrefab;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0f;
        SpawnBubble();
    }

    private void SpawnBubble()
    {
        GameObject thrownBubble = Instantiate(BubblePrefab);

        thrownBubble.transform.position = transform.position;
        thrownBubble.GetComponent<ThrowingBubbleProjectile>().SetDirection(playerMovement.transform.position.x, 0f);
    }

}
