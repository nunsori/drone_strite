using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample_c : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().Play("flash");
        Debug.Log("played");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
