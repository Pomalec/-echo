using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bushpuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public int type;
    public Animator anim;
    private void Awake()
    {
       // if (Random.value < 0.5f)
       //     type = 0;
       // else
       //     type = 1;
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 0)
        {
            anim.SetBool("greyish", true);
        }
        else
        {
            anim.SetBool("greyish", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"&&type==0)
        {
            Debug.Log("col");

            if (Input.GetKeyDown(KeyCode.Space))
            {

                Destroy(gameObject);
            }

        }
    }
    public int gettype()
    {
        return type;
    }
}
