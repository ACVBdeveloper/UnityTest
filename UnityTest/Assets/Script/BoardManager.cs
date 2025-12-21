using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{

    private Tilemap m_TileMap;
    public int width=8;
    public int height=8;
    public Tile[] groundTiles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_TileMap = GetComponentInChildren<Tilemap>();
        for( int i =0; i < height; i++){
            for(int j=0; j<width;j++){
                int tileNumber = Random.Range(0, groundTiles.Length);
                m_TileMap.SetTile(new Vector3Int(i, j, 0), groundTiles[tileNumber]);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
