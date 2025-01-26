using Unity.VisualScripting;
using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    [SerializeField] Vector2Int tilePosition;


    private void Start()
    {
        GetComponentInParent<WorldScrolling>().Add(gameObject, tilePosition);
    }
}
