using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    public int experience = 0;

    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    public void AddExperience(int amount)
    {
        experience += amount;

    }

    public void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;

            level += 1;
        }

    }
}
