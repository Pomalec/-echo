using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishspawner : MonoBehaviour
{
    [SerializeField]
    private GameObject fishprehab;
    // Start is called before the first frame update
    [SerializeField]
    private float minspwantime;
    [SerializeField]
    private float maxspwantime;

    private float timeuntilspawn;
    [SerializeField]
    bool spawn = true;
    private void Awake()
    {
        settimeuntilspawn();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            timeuntilspawn -= Time.deltaTime;
            if (timeuntilspawn <= 0)
            {
                var randy = Random.Range(-4f, 1f);
                var newpos=transform.position;

              
                    newpos.y = randy;
                    Instantiate(fishprehab, newpos, Quaternion.identity);
                
              
                    
                
                settimeuntilspawn();
            }
        }
    }
    private void settimeuntilspawn()
    {
        timeuntilspawn = Random.Range(minspwantime, maxspwantime);
    }
    public void setspawn()
    {
        spawn = true;
    }
}
