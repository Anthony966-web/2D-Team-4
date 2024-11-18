using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public int Wave = 0;
    public List<GameObject> Enemys = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        print(Enemys);
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(Enemys[Wave]);
    }
}
