using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class scoremanager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoretxt;
    public TextMeshProUGUI livesleft;

    public static int scorecount; public static int lives;
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        scoretxt.text = "Score: " + Mathf.Round(scorecount);
        livesleft.text= "x: " + Mathf.Round(lives);
    }
    public void addscore()
    {

    }
}
