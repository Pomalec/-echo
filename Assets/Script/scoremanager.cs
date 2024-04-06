using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class scoremanager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoretxt0;
    public TextMeshProUGUI livesleft;
    public TextMeshProUGUI scoretxt1;
   // public TextMeshProUGUI scoretxt2;
    public static int scorecount0; public static int lives;
    public static int scorecount1;
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        scoretxt0.text = "Score 0: " + Mathf.Round(scorecount0);
        scoretxt1.text = "Score 1: " + Mathf.Round(scorecount1);
        livesleft.text= "x: " + Mathf.Round(lives);
    }
    public void addscore()
    {

    }
}
