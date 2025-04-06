using System;
using UnityEngine;

[Serializable]
public abstract class CharacterAbs : MonoBehaviour
{
    public int Level = 1;
    public int Health = 100;
    public int Power;
    public Class _ClassType;
    public ArmyStatus _ArmyStatus;
}
