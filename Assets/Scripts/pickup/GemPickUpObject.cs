using UnityEngine;

public class GemPickUpObject : MonoBehaviour, IPickUpObject
{

    [SerializeField] int amount;
    public void OnPickUp(PlayerCharacter character)
    {
        character.level.AddExperience(amount);
    }
}
