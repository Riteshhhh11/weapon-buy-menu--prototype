using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableGuns", menuName = "Scriptable Objects/ScriptableGuns", order = 1)]
public class ScriptableGuns : ScriptableObject
{
    [Header("Information")]
    public string gunName;
    public string gunCategory;
    public float gunPrice;
    public float roundCapacity;

    [Header("Model")]
    public GameObject gunPrefab;
}
