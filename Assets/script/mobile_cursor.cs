using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobile_cursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.SetAsFirstSibling();
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
    }
}
