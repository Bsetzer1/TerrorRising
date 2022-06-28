using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float SetPoints;
    public Text PointDisplay;
    public float round;
    public Text RoundDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PointDisplay.text = SetPoints.ToString();
        RoundDisplay.text = round.ToString();
    }
}
