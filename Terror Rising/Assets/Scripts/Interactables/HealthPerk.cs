using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPerk : Interactable
{
    public HealthPerk Jug;
    public bool isClosed;
    public float PurchaseCost;
    public GameController CurrentPoints;
    public PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePerk();
    }
    void UpdatePerk()
    {
        Jug.enabled = isClosed;
    }

    public override string GetDescription()
    {
        if (isClosed) return "Press E For Health Increase " + PurchaseCost;
        return "Press E For Health Increase " + PurchaseCost;
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
            health.maxHealth = 200;
            isClosed = !isClosed;
            Destroy(gameObject);
            UpdatePerk();
        }
    }
}
