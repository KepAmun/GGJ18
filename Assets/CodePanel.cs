using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePanel : MonoBehaviour
{
    public MorseCodePlayer CodePlayer;

    TopDownCharacterController _character;

    private void Awake()
    {
        _character = FindObjectOfType<TopDownCharacterController>();
    }

    private void OnEnable()
    {
        _character.enabled = false;

        CodePlayer.StartPlayingMessage(GameManager.Instance.CurrentMessage);
    }

    private void OnDisable()
    {
        _character.enabled = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
}
