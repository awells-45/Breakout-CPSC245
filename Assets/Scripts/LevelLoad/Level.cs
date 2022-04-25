using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelScriptableObject", order = 1)]

public class Level : ScriptableObject
{
    private int numBricks;
    // public List<int> intList = new List<int>();
    public List<BlueprintBrick> bricks = new List<BlueprintBrick>();
}