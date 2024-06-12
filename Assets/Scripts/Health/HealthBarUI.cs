using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image healthBar;
    public void UpdateHealthBar(HealthController controller)
    {
        healthBar.fillAmount = controller.RemainingHealthPercentage;
    }
}
