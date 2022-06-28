using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : Interactable
{
    public Doors door;
    public bool isClosed;
    public float PurchaseCost;
    public GameController CurrentPoints;
    // Start is called before the first frame update
    void Start()
    {
        UpdateDoor();
    }
    void UpdateDoor()
    {
        door.enabled = isClosed;
    }

    public override string GetDescription()
    {
        if (isClosed) return "Press E to Open For " + PurchaseCost;
        return "Press E to Open For " + PurchaseCost;
    }

    public override void Interact()
    {
        if (CurrentPoints.SetPoints >= PurchaseCost)
        {
            CurrentPoints.SetPoints -= PurchaseCost;
            if(CurrentPoints.SetPoints <= 0)
            {
                CurrentPoints.SetPoints = 0;
            }
            isClosed = !isClosed;
            Destroy(gameObject);
            UpdateDoor();
        }
    }
}
