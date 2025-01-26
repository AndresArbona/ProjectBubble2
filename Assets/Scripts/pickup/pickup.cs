using UnityEngine;

public class pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCharacter character = GetComponent<PlayerCharacter>();

        if (character != null)
        {
            Debug.Log("pick");
            GetComponent<IPickUpObject>().OnPickUp(character);
            Destroy(gameObject);
        }
    }
}
