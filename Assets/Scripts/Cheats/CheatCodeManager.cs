using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheatCodeManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text responseText;
    [SerializeField] private List<CheatCode> cheats = new List<CheatCode>();

    public GameObject target;
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
            if (text.ToLower().Equals(cheat.Name))
            {
                cheat.Activate();
                responseText.text = cheat.ResponseText;
            }
        }
    }
}
