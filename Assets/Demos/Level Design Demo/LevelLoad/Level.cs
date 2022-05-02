/* a. Ian Reafsnyder, Lucas Torti, and Natalie Huante
 * b. 2337621, 2351555, 2374481
 * c. ireafsnyder@chapman.edu, torti@chapman.edu, huante@chapman.edu
 * d. CPSC 245-01
 * e. Brick buster class project
 *
 * A scriptable object representing a level and containing a list of BlueprintBricks
 * Used by LevelLoadManager to store a list of every level in the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelScriptableObject", order = 1)]

public class Level : ScriptableObject
{
    public List<BlueprintBrick> bricks = new List<BlueprintBrick>();
}