using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Vector2Int currentTilePosition = new Vector2Int(0,0);
    Vector2Int currentPlayerTilePosition;
    Vector2Int onTileGridPosition;
    [SerializeField] Vector2Int playerTilePosition;


    [SerializeField] float tileSize = 6.25f;
    GameObject[,] terrainTile;

    [SerializeField] int terrainTileHorizontalCount;
    [SerializeField] int terrainTileVerticalCount;   
    
    
    [SerializeField] int fieldOfVisionHeight = 3;
    [SerializeField] int fieldOfVisionWidth = 3;

    private void Awake()
    {
        terrainTile = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
    }

    private void Update()
    {
        currentTilePosition.x =(int)(playerTransform.position.x / tileSize);
        currentTilePosition.y =(int)(playerTransform.position.y / tileSize);

        if (currentTilePosition != playerTilePosition) { 

            currentTilePosition = playerTilePosition;

            UpdateOnTileGridPlayerPosition();
            UpdateTilesOnScreen();
        }
    }

    public void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terrainTile[tilePosition.x, tilePosition.y] = tileGameObject;
    }

    public int CalculatePositionOnAxisWithWrap(int currentValue, bool horizontal)
    {

        if (horizontal) 
        { 
            if(currentValue >= 0)
            {
                currentValue = currentValue % terrainTileHorizontalCount;
            }
            else
            {
                currentValue = terrainTileHorizontalCount - 1 
                    + currentValue % terrainTileHorizontalCount;
            }

        } else 
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileVerticalCount;
            }
            else
            {
                currentValue = terrainTileVerticalCount - 1
                    + currentValue % terrainTileVerticalCount;
            }
        }
        return (int)currentValue;
    }

    public void UpdateTilesOnScreen()
    {
        for (int pov_x = 0; pov_x < fieldOfVisionWidth; pov_x++) 
        { 
            for(int pov_y = 0; pov_y < fieldOfVisionHeight; pov_y++)
            {

            }

        }    
    }
}
