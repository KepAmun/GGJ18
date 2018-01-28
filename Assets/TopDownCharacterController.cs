using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopDownCharacterController : MonoBehaviour
{
    public GameObject DirtPilePrefab;
    public TMPro.TMP_Text HoverText;

    Rigidbody2D _rigidbody;

    Usable _nearbyUsable;

    bool _digging = false;

    Coroutine _diggingCoroutine;

    Animator _animator;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(_nearbyUsable != null)
            {
                _nearbyUsable.Use();
            }
            else
            {
                StartDigging();
            }
        }

        if(_nearbyUsable == null)
        {
            HoverText.text = string.Format("{0:F0},{1:F0}", transform.position.x, transform.position.y);
        }

    }


    private void FixedUpdate()
    {
        Vector2 v = new Vector2();

        if(!_digging)
        {
            v.x = Input.GetAxis("Horizontal") * 100;
            v.y = Input.GetAxis("Vertical") * 100;

            _rigidbody.AddForce(v);

            int direction = -1;

            if(v.x != 0 || v.y != 0)
            {
                bool horizontal = Mathf.Abs(v.x) >= Mathf.Abs(v.y);

                if(horizontal)
                {
                    if(v.x < 0)
                    {
                        direction = 0;
                    }
                    else
                    {
                        direction = 2;
                    }
                }
                else
                {
                    if(v.y > 0)
                    {
                        direction = 1;
                    }
                    else
                    {
                        direction = 3;
                    }
                }

            }

            _animator.SetInteger("Direction", direction);

        }
        else
        {
            _animator.SetInteger("Direction", -1);
        }

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
            HoverText.text = usable.DisplayName;

            _nearbyUsable = usable;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        _nearbyUsable = null;
    }

    void StartDigging()
    {
        if(_diggingCoroutine == null)
            _diggingCoroutine = StartCoroutine(Dig());
    }

    IEnumerator Dig()
    {
        _digging = true;
        _animator.SetBool("Digging", true);

        GameObject dirtPile = Instantiate(DirtPilePrefab, (Vector2)transform.position + (Vector2.down * 0.1f), Quaternion.identity);
        Vector3 targetScale = dirtPile.transform.localScale;
        dirtPile.transform.localScale = Vector3.zero;

        float startTime = Time.time;

        while(dirtPile.transform.localScale.x < targetScale.x)
        {
            float t = (Time.time - startTime)/2;

            dirtPile.transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, t);

            yield return null;
        }

        _digging = false;
        _diggingCoroutine = null;
        _animator.SetBool("Digging", false);


        startTime = Time.time;

        while(dirtPile.transform.localScale.x > 0)
        {
            float t = (Time.time - startTime) / 30;

            dirtPile.transform.localScale = Vector3.Lerp(targetScale, Vector3.zero, t);

            yield return null;
        }
    }

}
