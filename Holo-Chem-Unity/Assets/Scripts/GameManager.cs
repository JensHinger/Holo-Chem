using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private ScriptableObject[] recipes;


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
        // Get the name for both instantiated gameobjects
        string first_name = first.name.Remove(first.name.Length - 7);
        string second_name = second.name.Remove(second.name.Length - 7);

        // Iterate over every recipe
        foreach (CombinationRecipe recipe in recipes)
        {

            // Check the names against each recipe
            if (recipe.recipe[0].name == first_name && recipe.recipe[1].name == second_name || recipe.recipe[1].name == first_name && recipe.recipe[0].name == second_name)
            {
                // Calculate the Position of the collision
                Vector3 first_position = first.transform.position;
                Vector3 second_position = second.transform.position;
                Vector3 collision_position = new Vector3((first_position.x+second_position.x)/2, (first_position.y+second_position.y)/2, (first_position.z+second_position.z)/2);

                // Destroy the gameobjects which should be consumend
                Destroy(first);
                Destroy(second);

                // Instantiate the result prefab
                Instantiate(recipe.result, collision_position, recipe.result.transform.rotation);
            
                // ToDo: Transform Particle effect, Unlock spawnpoint for result
            }
        }

    }
}
