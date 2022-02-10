using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private ScriptableObject[] recipes;
    public ParticleSystem combinationEffect;
    public ParticleSystem badCombinationEffect;

    private GameObject[] spawnPoints;

    private void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
    }

    void OnEnable()
    {
        // Subscribe to Event
        HandleCollision.OnMaterialCollision += HandleCombination;
    }

    void OnDisable()
    {
        // Unsubscribe to Event
        HandleCollision.OnMaterialCollision -= HandleCombination;
    }

    void HandleCombination(GameObject first, GameObject second)
    {
        // To check if combination failed
        bool fail_combination = true;

        // Get the name for both instantiated gameobjects
        string first_name = first.name.Remove(first.name.Length - 7);
        string second_name = second.name.Remove(second.name.Length - 7);


        // Calculate the Position of the collision
        Vector3 first_position = first.transform.position;
        Vector3 second_position = second.transform.position;
        Vector3 collision_position = new Vector3((first_position.x + second_position.x) / 2, (first_position.y + second_position.y) / 2, (first_position.z + second_position.z) / 2);

        // Iterate over every recipe
        foreach (CombinationRecipe recipe in recipes)
        {

            // Check the names against each recipe
            if (recipe.recipe[0].name == first_name && recipe.recipe[1].name == second_name || recipe.recipe[1].name == first_name && recipe.recipe[0].name == second_name)
            {

                // Destroy the gameobjects which should be consumend
                Destroy(first);
                Destroy(second);

                // Instantiate and Play combinationEffect
                Instantiate(combinationEffect, collision_position, combinationEffect.transform.rotation);
                
                // Instantiate the result prefab
                Instantiate(recipe.result, collision_position, recipe.result.transform.rotation);

                // ToDo: Unlock spawnpoint for result
                foreach(GameObject spawnpoint in spawnPoints)
                {
                    SpawnManager spawnScript = spawnpoint.GetComponent<SpawnManager>();
                    string spawnObjectName = spawnScript.toSpawn.name;

                    if (spawnObjectName == recipe.result.name)
                    {
                        spawnScript.spawnActivated = true;
                    }
                }

                // Set the combination fail on true
                fail_combination = false;

                // Stop foreach loop when combination is found
                break;
            }
        }

        if (fail_combination) 
        { 
            // Destroy the gameobjects which should be consumend
            Destroy(first);
            Destroy(second);

            // Instantiate and Play combinationEffect
            Instantiate(badCombinationEffect, collision_position, badCombinationEffect.transform.rotation);
        }
        
    }
}
