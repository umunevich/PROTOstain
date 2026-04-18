using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MutationPlan", menuName = "Scriptable Objects/MutationPlan")]
public class MutationPlan : ScriptableObject
{
    public List<MutationLevel> levels;
}

[System.Serializable]
public struct MutationLevel
{
    public float requiredPoints;
    public float growthSpeed;
    public float damage;
    public Vector3 scale;
}
