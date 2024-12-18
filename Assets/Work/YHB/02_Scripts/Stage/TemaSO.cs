using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Tema")]
public class TemaSO : ScriptableObject
{
    public Common.Tema tema;
    public List<StageSO> stages;
}