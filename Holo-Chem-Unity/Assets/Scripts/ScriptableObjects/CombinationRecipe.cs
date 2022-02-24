using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CombinationRecipe : ScriptableObject
{
    public bool isEndProduct = false;
    public GameObject[] recipe;
    public GameObject result;
}
