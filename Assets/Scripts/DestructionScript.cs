using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AlexzanderCowell
{
    public class DestructionScript : MonoBehaviour
    {
        [Range(-100, 100)] [SerializeField] private int gridSizeX;
        [Range(-100, 100)] [SerializeField] private int gridSizeY;
        [Range(-1, 3)] [SerializeField] private float cellSize;
        [Range(-100, 100)] [SerializeField] private float adjustableXSize;
        [Range(-100, 100)] [SerializeField] private float adjustableYSize;
        [Range(-100, 100)] [SerializeField] private int cellSizingX;
        [Range(-100, 100)] [SerializeField] private int cellSizingY;
        private int[,] grid; // Represents the state of each grid cell
        [Header("Tile Prefab")]
        [SerializeField] private Object gridCellPrefab;
        private Vector3 gridCenter;
        private GameObject spawnTile;
        private Vector3 cellCenter;

        
        
        private void Start()
        {
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            grid = new int[gridSizeX, gridSizeY];
            gridCenter = transform.position + new Vector3((gridSizeX - adjustableXSize) * cellSize / 1, (gridSizeY - adjustableYSize) * cellSize / 1, 0f);
            
            // Initialize the grid, for example:
            for (int x = cellSizingX; x < gridSizeX; x++)
            {
                for (int y = cellSizingY; y < gridSizeY; y++)
                {
                    cellCenter = gridCenter + new Vector3(x * cellSize, y * cellSize, 0f);
                    spawnTile = (Instantiate(gridCellPrefab, cellCenter, Quaternion.identity) as GameObject);
                    spawnTile.name = $"Tile {x} {y}";
                    spawnTile.transform.parent = gameObject.transform;
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            grid = new int[gridSizeX, gridSizeY];
            gridCenter = transform.position + new Vector3((gridSizeX - adjustableXSize) * cellSize / 1, (gridSizeY - adjustableYSize) * cellSize / 1, 0f);
            
            for (int x = cellSizingX; x < gridSizeX; x++)
            {
                for (int y = cellSizingY; y < gridSizeY; y++)
                {
                    cellCenter = gridCenter + new Vector3(x * cellSize, y * cellSize, 0f);
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireCube(cellCenter, new Vector3(cellSize, cellSize, 0f));
                }
            }
        }
    }
}
