using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] PlayerCharacter playerCharacter;
    public  Slider slider;

    public void ChangeLifeMax()
    {
        slider.maxValue = playerCharacter.maxHealth;
    }

    public void ChangeLifeAct()
    {
        slider.value = playerCharacter.currentHealth / playerCharacter.maxHealth ;
    }

    public void ReadyHealthBar()
    {
        ChangeLifeMax();
        ChangeLifeAct();
    }
}
