using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOcclusion : MonoBehaviour
{
    public bool Dynamic = false;

    SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();

        _renderer.sortingOrder = (int)(transform.position.y * -1000);

        if(Dynamic)
            StartCoroutine(UpdateOrder());
    }


    private IEnumerator UpdateOrder()
    {
        while(true)
        {
            _renderer.sortingOrder = (int)(transform.position.y * -1000);

            yield return null;
        }
    }
    
}
