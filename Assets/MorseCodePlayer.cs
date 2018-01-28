using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MorseCodePlayer : MonoBehaviour
{
    public AudioClip DotSound;
    public AudioClip DashSound;

    public SpriteRenderer TargetSpriteRenderer;
    public Image TargetImage;

    float _dotDuration = 0.09f;
    float _dashDuration;
    float _spaceDuration;

    AudioSource _audio;


    Dictionary<char, string> _characterCodes = new Dictionary<char, string> {
    {'A',"._"},
    {'B',"_..."},
    {'C',"_._."},
    {'D',"_.."},
    {'E',"."},
    {'F',".._."},
    {'G',"__."},
    {'H',"...."},
    {'I',".."},
    {'J',".___"},
    {'K',"_._"},
    {'L',"._.."},
    {'M',"__"},
    {'N',"_."},
    {'O',"___"},
    {'P',".__."},
    {'Q',"__._"},
    {'R',"._."},
    {'S',"..."},
    {'T',"_"},
    {'U',".._"},
    {'V',"..._"},
    {'W',".__"},
    {'X',"_.._"},
    {'Y',"_.__"},
    {'Z',"__.."},
    {'1',"._"},
    {'2',".._"},
    {'3',"..._"},
    {'4',"...._"},
    {'5',"....."},
    {'6',"_...."},
    {'7',"_..."},
    {'8',"_.."},
    {'9',"_."},
    {'0',"_____"},
    };


    private void Awake()
    {
        _dashDuration = _dotDuration * 3;
        _spaceDuration = _dotDuration * 7;

        _audio = GetComponent<AudioSource>();

        StartPlayingMessage("SOS SOS");
    }


    public void StartPlayingMessage(string message)
    {
        StartCoroutine(PlayMessage(message));
    }


    IEnumerator PlayMessage(string message)
    {
        message = message.ToUpper();

        foreach(var character in message)
        {
            if(char.IsWhiteSpace(character))
            {
                yield return new WaitForSeconds(_spaceDuration);
            }
            else if(_characterCodes.ContainsKey(character))
            {
                string code = _characterCodes[character];

                foreach(var c in code)
                {
                    TargetSpriteRenderer.enabled = true;
                    TargetImage.enabled = true;

                    if(c == '.')
                    {
                        _audio.PlayOneShot(DotSound);
                        yield return new WaitForSeconds(_dotDuration);
                    }
                    else
                    {
                        _audio.PlayOneShot(DashSound);
                        yield return new WaitForSeconds(_dashDuration);
                    }

                    TargetSpriteRenderer.enabled = false;
                    TargetImage.enabled = false;

                    yield return new WaitForSeconds(_dotDuration);
                }
            }
        }

    }


}
/*
A .-
B -...
C -.-.
D -..
E .
F ..-.
G --.
H ....
I ..
J .---
K -.-
L .-..
M --
N -.
O ---
P .--.
Q --.-
R .-.
S ...
T -
U ..-
V ...-
W .--
X -..-
Y -.--
Z --..
1 .----
2 ..---
3 ...--
4 ....-
5 .....
6 -....
7 --...
8 ---..
9 ----.
0 -----

 */
