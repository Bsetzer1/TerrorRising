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
    public AudioSource Music;
    public PlayerHealth Godmode;
    public Gun UnlimitedAmmo;
    // Start is called before the first frame update
    void Start()
    {
        Music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        PointDisplay.text = SetPoints.ToString();
        RoundDisplay.text = round.ToString();
        if (Input.GetKeyDown(KeyCode.T))
        {
            Godmode.currentHealth = 9999999999999999999999999999f;
            Godmode.maxHealth = 9999999999999999999999999999f;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            UnlimitedAmmo.AmmoCount = 99999999999999999999999999999999999f;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            SetPoints = 999999999999999999999999999999999f;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            UnlimitedAmmo.damage = 999f;
        }
    }
}
