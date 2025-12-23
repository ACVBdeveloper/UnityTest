using UnityEngine;

public class TurnManager
{
    private int m_TurnCount;

    public TurnManager()
    {
        m_TurnCount = 1;
    }

    public void Tick() 
    {
        m_TurnCount++;
        Debug.Log("Current Turn: " + m_TurnCount);
    }

}
