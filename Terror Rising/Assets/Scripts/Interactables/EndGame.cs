using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : Interactable
{
    public EndGame door;
    public bool isClosed;
    public float PurchaseCost;
    public GameController CurrentPoints;
    public GameOverScreen GameOverScreen;
    public GameController points;
    public PlayerHealth GameOvers;
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
        if (isClosed) return "Press E to Escape " + PurchaseCost;
        return "Press E to Escape " + PurchaseCost;
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
            GameOvers.GameOver = true;
            GameOverScreen.Setup(points.SetPoints);
            isClosed = !isClosed;
            UpdateDoor();
        }
    }
}
