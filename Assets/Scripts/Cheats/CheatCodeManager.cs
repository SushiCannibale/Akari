using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheatCodeManager : MonoBehaviour
{
    // public static event Action PlayerCheatActivation; 
    // public static event Action PlayerCheatDesactivation; 
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text responseText;
    [SerializeField] List<Cheat> Cheats = new List<Cheat>();
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CheckCheat(inputField.text);
        }
    }

    private void CheckCheat(string text)
    {
        string lower = text.ToLower();
        // Cheat queried = Cheats.Find(cheat => lower.Equals(cheat.Name) || lower.Equals(cheat.DesacName));

        Cheats.ForEach(cheat =>
        {
            if (!cheat.IsActive && lower.Equals(cheat.Name))
            {
                cheat.Activate();
                StartCoroutine(WriteCheatTextFor(1, cheat.ResponseText));
            }
            else if (lower.Equals(cheat.DesacName))
            {
                cheat.Desactivate();
            }
        });
    }

    IEnumerator WriteCheatTextFor(float seconds, string text)
    {
        responseText.SetText(text);
        yield return new WaitForSeconds(seconds);
        responseText.SetText("");
    }
}
