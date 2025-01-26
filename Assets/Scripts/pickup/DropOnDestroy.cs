using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject dropItemPrefab;
    [SerializeField][Range(0f,1f)] float dropChance = 1f;

    private void OnDestroy()
    {
        if (Random.value < dropChance)
        {
            Transform t = Instantiate(dropItemPrefab).transform;
            t.position = transform.position;
        }
    }

}
