using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : Interactable
{
    public AmmoBox Ammo;
    public bool isClosed;
    public float PurchaseCost;
    public GameController CurrentPoints;
    public Gun AmmoReset;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePerk();
    }
    void UpdatePerk()
    {
        Ammo.enabled = isClosed;
    }

    public override string GetDescription()
    {
        if (isClosed) return "Press E For Reserve Ammo Increase " + PurchaseCost;
        return "Press E For Reserve Ammo Increase " + PurchaseCost;
    }

    public override void Interact()
    {
        if (CurrentPoints.SetPoints >= PurchaseCost)
        {
            CurrentPoints.SetPoints -= PurchaseCost;
            if (CurrentPoints.SetPoints <= 0)
            {
                CurrentPoints.SetPoints = 0;
            }
            AmmoReset.ReserveAmmo = AmmoReset.MaxAmmo;
            isClosed = !isClosed;
            UpdatePerk();
        }
    }
}
