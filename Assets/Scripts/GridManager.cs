using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public int gridSizeX;
    public int gridSizeY;
    public float cellSize;
    public Tile[,] _grid;

    public Tile tilePrefab;

    public float minePercentage = 0.2f; // May�n y�zdesi
    private List<Vector2Int> minePositions = new List<Vector2Int>(); // May�n konumlar�n� tutacak liste

    private void Start()
    {
        CreateGrid();
        Vector3 newPosition = new Vector3(28.2f, -2.9f, 30.2f);
        transform.position = newPosition;

        Vector3 newRotation = new Vector3(-72.886f, 179.264f, -3.437f);
        transform.eulerAngles = newRotation;

        PlaceMines();
    }

    private void CreateGrid()
    {
        _grid = new Tile[gridSizeX, gridSizeY];

        for (int y = 0; y < gridSizeY; y++)
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                Vector3 position = new Vector3(x * cellSize, y * cellSize, 0);
                Tile newTile = Instantiate(tilePrefab);
                _grid[x, y] = newTile;

                newTile.transform.parent = transform;
                newTile.transform.localPosition = position;
            }
        }

        Vector3 centerOffset = new Vector3(gridSizeX * cellSize * 0.5f, gridSizeY * cellSize * 0.5f, 0);
        transform.position = -centerOffset;
    }

    private void PlaceMines()
    {
        int totalTiles = gridSizeX * gridSizeY;
        int totalMines = Mathf.RoundToInt(totalTiles * minePercentage);

        for (int i = 0; i < totalMines; i++)
        {
            int x = Random.Range(0, gridSizeX);
            int y = Random.Range(0, gridSizeY);

            // E�er bu konumda zaten bir may�n varsa, tekrar se�mek i�in i'yi azalt
            if (minePositions.Contains(new Vector2Int(x, y)))
            {
                i--;
            }
            else
            {
                minePositions.Add(new Vector2Int(x, y));
                _grid[x, y].Prepare(UnitState.Mine); // May�n� prepare etmek i�in tile'�n UnitState'ini Mine olarak ayarl�yoruz
            }
        }
    }
}
