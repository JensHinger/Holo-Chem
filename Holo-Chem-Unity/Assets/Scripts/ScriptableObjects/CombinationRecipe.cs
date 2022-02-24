using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CombinationRecipe : ScriptableObject
{
    public bool isEndProduce = false;
    public GameObject[] recipe;
    public GameObject result;
}
