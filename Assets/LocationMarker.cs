using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocationMarker : MonoBehaviour {

    TMP_Text text;
    
    private void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
        text.text = string.Format("{0}{1}", (char)('A' + Mathf.RoundToInt(transform.position.x + 0.5f)), (char)('A' + Mathf.RoundToInt(transform.position.y + 17.5f)));
    }


    private void Start()
    {
        //text.= GetComponent<SpriteRenderer>().sortingOrder;
    }
}
