using UnityEngine;

public class FoodObject : CellObject
{

    public int amountGranted = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void PlayerEntered() 
    {
        Destroy(this.gameObject);
        //Increase Food Score
        Debug.Log("Food eaten!");

        //increase food

        GameManager.Instance.changeFood(amountGranted);
    }
}
