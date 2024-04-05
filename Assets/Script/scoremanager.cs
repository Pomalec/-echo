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
    public static int scorecount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoretxt.text= "Score: " + Mathf.Round(scorecount);
    }
    public void addscore()
    {

    }
}
