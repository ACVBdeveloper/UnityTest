using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public BoardManager boardManager;
    public PlayerController playerController;
    public TurnManager turnManager { get; private set; }
    private int storeFood;
    public UIDocument uiDoc;

    private Label m_FoodLabel;


    
    private void Awake() 
    {
        if (Instance != null) 
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        storeFood = Random.Range(5, 100);
        m_FoodLabel = uiDoc.rootVisualElement.Q<Label>("FoodLabel");
        m_FoodLabel.text = "Food: " + storeFood;
        turnManager = new TurnManager();
        turnManager.OnTick += OnTurnHappens;
        boardManager.Init();
        playerController.Spawn(boardManager,new Vector2Int(1,1));
        
    }

    // Update is called once per frame
    void Update()
    {
   
        
        
    }

    public void OnTurnHappens() 
    {
        changeFood(-1);
    }

    public void changeFood(int amount)
    {
        storeFood += amount;
        m_FoodLabel.text = "Food: " + storeFood;
    }
}
