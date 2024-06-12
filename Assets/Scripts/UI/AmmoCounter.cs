using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI ammoCounter;

    public void UpdateCounter(int curAmmo, int magSize)
    {
        ammoCounter.text = curAmmo.ToString() + " / " + magSize.ToString();
    }
}
