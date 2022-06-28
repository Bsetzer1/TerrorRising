using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintPerk : Interactable
{
    public SprintPerk sprint;
    public bool isClosed;
    public float PurchaseCost;
    public GameController CurrentPoints;
    public PlayerMotor SprintIncrease;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePerk();
    }
    void UpdatePerk()
    {
        sprint.enabled = isClosed;
    }

    public override string GetDescription()
    {
        if (isClosed) return "Press E For MoveSpeed Increase " + PurchaseCost;
        return "Press E For MoveSpeed Increase " + PurchaseCost;
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
            SprintIncrease.speed = SprintIncrease.speed * 1.5f;
            isClosed = !isClosed;
            Destroy(gameObject);
            UpdatePerk();
        }
    }
}
