using UnityEngine;
using UnityEngine.Tilemaps;

public class WallObject : CellObject
{

    public Tile obstacleTile;
    public int maxHealth = 3;

    private int m_HealthPoint;
    private Tile m_OriginalTile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Init(Vector2Int  cell)
    {
        base.Init(cell);
        
        m_HealthPoint = maxHealth;

        m_OriginalTile = GameManager.Instance.boardManager.GetCellTile(cell);
        GameManager.Instance.boardManager.SetTileCell(cell,obstacleTile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override bool PlayerWantsToEnter()
    {
        m_HealthPoint -= 1;
        if (m_HealthPoint>0) 
        {
            return false;
        }
        
        GameManager.Instance.boardManager.SetTileCell(m_Cell,m_OriginalTile);
        return true;
    }
}
