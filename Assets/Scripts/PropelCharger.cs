using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropelCharger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {




        if (collision.CompareTag("Player"))
        {


            Player P = collision.GetComponent<Player>();
            if (P != null)
            {
                P.RechargePropel();
                Destroy(gameObject);
            }


        }
    }
}
