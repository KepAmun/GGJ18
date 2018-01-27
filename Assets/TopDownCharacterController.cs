using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopDownCharacterController : MonoBehaviour
{
    public Text TargetUseText;

    Rigidbody2D _rigidbody;

    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    

	void Update ()
    {
    }


    private void FixedUpdate()
    {
        Vector2 v = new Vector2();
        v.x = Input.GetAxis("Horizontal") * 100;
        v.y = Input.GetAxis("Vertical") * 100;

        _rigidbody.AddForce(v);

        if(v.sqrMagnitude > 0.001f)
        {
            _rigidbody.drag = 20;
        }
        else
        {
            _rigidbody.drag = 1000;
        }
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Usable usable = collision.GetComponent<Usable>();

        if(usable != null)
        {
            TargetUseText.enabled = true;
            TargetUseText.text = usable.DisplayName;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        TargetUseText.enabled = false;
    }

}
