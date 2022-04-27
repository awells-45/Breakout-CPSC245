//Created by Ian Reafsnyder and Lucas Torti
//Purpose: Stores information about a level to be loaded. Is a Scriptable Object, which allows us to save it in the Unity editor Assets

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelScriptableObject", order = 1)]

public class Level : ScriptableObject
{
    public List<BlueprintBrick> bricks = new List<BlueprintBrick>();
}