using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "ScriptableObjects/EntityData")]
public class EntityData : ScriptableObject
{
    [SerializeField] public float blinkInterval;
    [SerializeField] public int blinkTimes;
    [SerializeField] public float maxHealth;
    [SerializeField] public float speed;
    [SerializeField] public float baseDamage;
    [SerializeField] public float maxInvulnerableTime;
}
