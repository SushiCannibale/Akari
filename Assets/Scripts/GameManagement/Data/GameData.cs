using System;
using UnityEngine;
using Random = System.Random;

[Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public Vector3 camOffset;
    public string scene;

    public SerializedGuardianData stoneGuardianData;
    public SerializedGuardianData sandGuardianData;

    public int wtfValue;

    // public GameData(Vector3 defaultPos, Vector3 camOffsetDefault, string sceneName, SerializedGuardianData stoneData, SerializedGuardianData sandData)
    // {
    //     // should be the default position when the game is started
    //     playerPosition = defaultPos;
    //     camOffset = camOffsetDefault;
    //     scene = sceneName;
    //     stoneGuardianData = stoneData;
    //     sandGuardianData = sandData;
    // }

    public GameData()
    {
        playerPosition = new Vector3(-1f, 1f, 4f);
        camOffset = new Vector3(-5, 6, -5);
        scene = Util.Scenes.FirstGameScene;
        stoneGuardianData = new SerializedGuardianData(new Vector3(10.5f,2.3f,36.475f), false);
        sandGuardianData = new SerializedGuardianData(new Vector3(-11.13f,1.75f,59.0f), false);
        wtfValue = new Random().Next(0, 101);
    }
}