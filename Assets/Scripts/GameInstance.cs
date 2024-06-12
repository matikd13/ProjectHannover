using Objects.Items;
using Player;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public GameObject player;
    public Inventory playerInventory;
    public PlayerController playerController;
    
    #region Singleton

    public static GameInstance Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More then one Inventory");
        }
        Instance = this;
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = player.GetComponent<Inventory>();
        playerController = player.GetComponent<PlayerController>();

        if (playerInventory == null)
        {
            playerInventory = player.AddComponent<Inventory>();
        }
        
        if (playerController == null)
        {
            playerController = player.AddComponent<PlayerController>();
        }
    }

    #endregion

}
