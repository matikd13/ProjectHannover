using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI ammoCounter;

    private int lastCurAmmo = 0;
    private int lastMagSize = 0;

    public void UpdateCounter(int curAmmo, int magSize)
    {
        lastCurAmmo = curAmmo;
        lastMagSize = magSize;
        ammoCounter.text = GameInstance.Instance.magCount.ToString() + "\n" + curAmmo.ToString() + " / " + magSize.ToString();
    }

    public void UpdateMag()
    {
        ammoCounter.text = GameInstance.Instance.magCount.ToString() + "\n" + lastCurAmmo.ToString() + " / " + lastMagSize.ToString();
    }
}
