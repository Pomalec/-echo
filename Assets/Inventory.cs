using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public static bool rod;
    [SerializeField]
    public static int cobwebs;
    [SerializeField]
    public static bool fishingminigame;
    [SerializeField]
    public static bool bookminigame;
    private void Awake()
    {
        rod = false;
        cobwebs = 0;
        fishingminigame = false;
        bookminigame = false;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
       
    }
    public void addcobwebs()
    {
        cobwebs++;
    }
   public  int getcobwebs()
    {
        return cobwebs;
    }
    public bool bothminigamesdone()
    {
        if (fishingminigame && bookminigame)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void equiprod()
    {
        rod = true;
    }
    public bool isrodequipped()
    {
        return rod;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(isrodequipped());
    }
}
