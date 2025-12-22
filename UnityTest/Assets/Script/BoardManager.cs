using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{

    public class CellData 
    {
        public bool passable;
    }
   
    private CellData[,] m_BoardData;
    private Tilemap m_TileMap;
    public int width=8;
    public int height=8;
    public Tile[] groundTiles;
    public Tile[] wallTiles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_TileMap = GetComponentInChildren<Tilemap>();

        m_BoardData = new CellData[width, height];

        for( int i =0; i < height; i++){
            for(int j=0; j<width;j++){
                //int tileNumber = Random.Range(0, groundTiles.Length);
                //m_TileMap.SetTile(new Vector3Int(i, j, 0), groundTiles[tileNumber]);
                Tile tile;
                m_BoardData[i,j] = new CellData();

                if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                {
                    tile = wallTiles[Random.Range(0, wallTiles.Length)];
                    m_BoardData[i,j].passable = false;
                }
                else {
                    tile = groundTiles[Random.Range(0, groundTiles.Length)];
                    m_BoardData[i,j].passable = true;
                }

                m_TileMap.SetTile(new Vector3Int(i, j, 0), tile);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
