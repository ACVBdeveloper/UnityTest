using UnityEngine;
using UnityEngine.Tilemaps;

public class WallObject : CellObject
{

    public Tile obstacleTile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Init(Vector2Int  cell)
    {
        base.Init(cell);
        GameManager.Instance.boardManager.SetTileCell(cell,obstacleTile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override bool PlayerWantsToEnter()
    {
        return false;
    }
}
