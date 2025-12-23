using NUnit.Framework;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour
{

    public class CellData 
    {
        public bool passable;
        public GameObject containerObject;
    }
   
    private CellData[,] m_BoardData;
    private Tilemap m_TileMap;
    public int width=8;
    public int height=8;
    public Tile[] groundTiles;
    public Tile[] wallTiles;
    private Grid m_Grid;
    public PlayerController Player;
    public GameObject foodPrefab;
    private List<Vector2Int> m_EmptyCellsList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //int tileNumber = Random.Range(0, groundTiles.Length);
    //m_TileMap.SetTile(new Vector3Int(i, j, 0), groundTiles[tileNumber]);
    public void Init()
    {
        m_TileMap = GetComponentInChildren<Tilemap>();
        m_Grid = GetComponentInChildren<Grid>();

        // Initialize List

        m_EmptyCellsList = new List<Vector2Int>();

        m_BoardData = new CellData[width, height];

        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {
                Tile tile;
                m_BoardData[x, y] = new CellData();

                if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                {
                    tile = wallTiles[Random.Range(0, wallTiles.Length)];
                    m_BoardData[x, y].passable = false;
                }
                else
                {
                    tile = groundTiles[Random.Range(0, groundTiles.Length)];
                    m_BoardData[x, y].passable = true;
                    m_EmptyCellsList.Add(new Vector2Int(x, y));
                }

                m_TileMap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }

        m_EmptyCellsList.Remove(new Vector2Int(1, 1));
        GenerateFood();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 CellToWorld(Vector2Int cellIndex) 
    {
        return m_Grid.GetCellCenterWorld((Vector3Int)cellIndex);
    }

    public CellData GetCellData(Vector2Int cellIndex) 
    {
        if (cellIndex.x < 0 || cellIndex.x >= width || cellIndex.y < 0 || cellIndex.y >= height) 
        {
            return null;
        }
        return m_BoardData[cellIndex.x, cellIndex.y];
    }

    void GenerateFood() 
    {
        int countFood = 5;
        for (int i =0; i < countFood; ++i) 
        {
            int ramdomIndex = Random.Range(0, m_EmptyCellsList.Count);
            Vector2Int coord = m_EmptyCellsList[ramdomIndex];

            m_EmptyCellsList.RemoveAt(ramdomIndex);
            CellData data = m_BoardData[coord.x, coord.y];
            GameObject newFood = Instantiate(foodPrefab);
            newFood.transform.position = CellToWorld(coord);
            data.containerObject = newFood;
        }
    }
}
