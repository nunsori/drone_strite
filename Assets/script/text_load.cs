using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class text_load : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = game_manage.Instance.total_count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
