using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Vector2Int currentTilePosition = new Vector2Int(0,0);
    Vector2Int onTileGridPosition;
    [SerializeField] Vector2Int playerTilePosition;


    [SerializeField] float tileSize = 12.5f;
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
        playerTilePosition.x =(int)(playerTransform.position.x / tileSize);
        playerTilePosition.y =(int)(playerTransform.position.y / tileSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1: 0;
        playerTilePosition.y -= playerTransform.position.y < 0 ? 1: 0;

        if (currentTilePosition != playerTilePosition) { 

            currentTilePosition = playerTilePosition;

            onTileGridPosition.x = CalculatePositionOnAxis(onTileGridPosition.x, true);
            onTileGridPosition.y = CalculatePositionOnAxis(onTileGridPosition.y, false);

            UpdateTilesOnScreen();
        }
    }

    public void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terrainTile[tilePosition.x, tilePosition.y] = tileGameObject;
    }

    public int CalculatePositionOnAxis(int currentValue, bool horizontal)
    {

        if (horizontal) 
        { 
            if(currentValue >= 0)
            {
                currentValue = currentValue % terrainTileHorizontalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileHorizontalCount - 1 
                    + currentValue % terrainTileHorizontalCount;
            }

        } 
        else 
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileVerticalCount - 1
                    + currentValue % terrainTileVerticalCount;
            }
        }
        return (int)currentValue;
    }

    public void UpdateTilesOnScreen()
    {
        for (int pov_x = -(fieldOfVisionWidth/2); pov_x <= fieldOfVisionWidth/2; pov_x++) 
        { 
            for(int pov_y = -(fieldOfVisionHeight/2); pov_y <= fieldOfVisionHeight/2; pov_y++)
            {
                int tileToUpdate_x = CalculatePositionOnAxis(playerTilePosition.x + pov_x, true);
                int tileToUpdate_y = CalculatePositionOnAxis(playerTilePosition.y + pov_y, false);

                GameObject tile = terrainTile[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position = CalculateTilePosition(
                    playerTilePosition.x + pov_x,
                    playerTilePosition.y + pov_y);
            }

        }    
    }

    public Vector3 CalculateTilePosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize,0.0f);
    }
}
