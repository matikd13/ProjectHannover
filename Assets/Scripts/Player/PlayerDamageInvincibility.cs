using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageInvincibility : MonoBehaviour
{
    [SerializeField] float invincibilityDuration;
    private InvincibilityController invController;

    private void Awake()
    {
        invController = GetComponent<InvincibilityController>();
    }

    public void StartInvincibility()
    {
        invController.StartInvincibility(invincibilityDuration);
    }
}
