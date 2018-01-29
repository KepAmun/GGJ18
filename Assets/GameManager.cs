using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MorseCodePlayer _codePlayer;

    public string[] Messages = { "   SOS", "H I", "G O", "B Y", "A M", "O R", "B E", "M Y", "F O", "O D", };

    int _currentIndex = 0;
    
    public string CurrentMessage
    {
        get { return Messages[_currentIndex]; }
    }



    public static GameManager Instance { get; private set; }


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    private void Start()
    {
        _codePlayer.StartPlayingMessage(Messages[_currentIndex]);

        _currentIndex++;
    }


    public void ObjectFound()
    {
        _currentIndex++;
    }

}
