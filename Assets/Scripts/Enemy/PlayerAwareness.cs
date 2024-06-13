using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwareness : MonoBehaviour
{
    public bool AwareOfPlayer = false;

    [SerializeField] private float DistanceAwarness = 40f;
    private Transform Player;

    public Vector2 DirectionToPlayer;

    private void Awake()
    {
        Player = FindFirstObjectByType<PlayerMovement>().transform;
    }

    void Update()
    {
        Vector2 positionBetween = Player.position - transform.position;

        DirectionToPlayer = positionBetween;

        if (DirectionToPlayer.magnitude <= DistanceAwarness)
        {
            AwareOfPlayer = true;
            // Debug.Log("Akuku widze Cie");
            // Debug.Log(DirectionToPlayer.magnitude);
        } 
        else
        {
            AwareOfPlayer = false;
            // Debug.Log("Nie widze gdzie jestes??");
        }
    }
}
