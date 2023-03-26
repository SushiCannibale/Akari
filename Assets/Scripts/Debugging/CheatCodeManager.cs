using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheatCodeManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Text responseText;
    [SerializeField] private List<CheatCode> cheats = new List<CheatCode>();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CheckCheat(inputField.text);
        }
    }

    private void CheckCheat(string text)
    {
        foreach (CheatCode cheat in cheats)
        {
            if (text.Equals(cheat.Name))
            {
                cheat.Activate();
                responseText.text = cheat.ResponseText;
            }
        }
    }
}
