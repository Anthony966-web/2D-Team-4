using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("HHDW");
            if(collision.CompareTag("Player"))
            {
            Debug.Log(gameObject.name);
            gameObject.SetActive(false);
            transform.parent = collision.transform;
            Destroy(gameObject);
            }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
