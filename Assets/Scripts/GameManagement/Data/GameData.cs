using System;
using UnityEngine;

[Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public Vector3 camOffset;
    public string scene;

    public bool stoneGuardianDead;
    public bool sandGuardianDead;

    public GameData(Vector3 defaultPos, Vector3 camOffsetDefault, string sceneName, bool stonedead, bool sanddead)
    {
        // should be the default position when the game is started
        playerPosition = defaultPos;
        camOffset = camOffsetDefault;
        scene = sceneName;
        stoneGuardianDead = stonedead;
        sandGuardianDead = sanddead;
    }

    public GameData()
    {
        playerPosition = new Vector3(-1f, 1f, 4f);
        camOffset = new Vector3(-5, 6, -5);
        scene = Util.Scenes.FirstGameScene;
        stoneGuardianDead = false;
        sandGuardianDead = false;
    }
}