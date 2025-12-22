using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private BoardManager m_Board;
    private Vector2Int cellPosition;

    public void Spawn(BoardManager boardManager, Vector2Int cell)
    {
        m_Board = boardManager;
        cellPosition = cell;
        //Let's move to the right positionR
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
