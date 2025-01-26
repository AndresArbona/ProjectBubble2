using UnityEngine;

public class pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("LLEGO!");
        PlayerCharacter character = collision.GetComponent<PlayerCharacter>();

        if (character != null)
        {
            Debug.Log("pick");
            GetComponent<IPickUpObject>().OnPickUp(character);
            Destroy(gameObject);
        }
    }
}
