using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePerk : Interactable
{
    public FirePerk Fire;
    public bool isClosed;
    public float PurchaseCost;
    public GameController CurrentPoints;
    public Gun FireRateIncrease;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePerk();
    }
    void UpdatePerk()
    {
        Fire.enabled = isClosed;
    }

    public override string GetDescription()
    {
        if (isClosed) return "Press E For FireRate Increase " + PurchaseCost;
        return "Press E For FireRate Increase " + PurchaseCost;
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
            FireRateIncrease.fireRate = FireRateIncrease.fireRate * 2f;
            isClosed = !isClosed;
            Destroy(gameObject);
            UpdatePerk();
        }
    }
}
