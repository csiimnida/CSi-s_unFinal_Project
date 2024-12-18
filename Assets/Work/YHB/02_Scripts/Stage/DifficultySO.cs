using Library;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Difficulty")]
public class DifficultySO : ScriptableObject
{
    public int number;
    public List<StageSO> stages;
}