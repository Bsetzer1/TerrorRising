using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePerk : Interactable
{
    public DamagePerk Tap;
    public bool isClosed;
    public float PurchaseCost;
    public GameController CurrentPoints;
    public Gun DamageIncrease;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePerk();
    }
    void UpdatePerk()
    {
        Tap.enabled = isClosed;
    }

    public override string GetDescription()
    {
        if (isClosed) return "Press E For Damage Increase " + PurchaseCost;
        return "Press E For Damage Increase " + PurchaseCost;
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
            DamageIncrease.damage = DamageIncrease.damage * 2f;
            isClosed = !isClosed;
            Destroy(gameObject);
            UpdatePerk();
        }
    }
}
