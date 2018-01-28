using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Usable
{
    public GameObject MorseCodePanel;

    public override void Use()
    {
        base.Use();

        MorseCodePanel.SetActive(true);
    }
}
