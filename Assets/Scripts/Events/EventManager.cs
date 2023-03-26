using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action PlayerCheatEvent;

    public static void onCheat()
    {
        PlayerCheatEvent?.Invoke();
    }
}
