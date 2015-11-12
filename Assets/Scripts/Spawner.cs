using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 
/// Develop by: Quinton "Kiro" Baudoin
///         
///     Purpose: To instantiat gameObjects with a set limit and timer.
///     
///    4 spawn types:
///     -    Stop At Limit: If limit is reached this script will stop running.
///     -    Wait At Limit: If limit is reached this script will wait till one of the gameObjects that this script spawned
///                         is destroyed(set to null) before spawning another.
///     -    Distroy At Limit: If limit is reached this script will destroy the earliest gameObject this script spawned, then spawn a new one.
///     -    No Limit: Ignors Limit.
/// 
/// 
/// </summary>



public class Spawner : MonoBehaviour
{



    void Start()
    {
        index = 0;
        StartCoroutine(Spawn());
    }

    /// <summary>
    /// Spawns prefabs based on information provided
    /// </summary>
    /// <returns></returns>
    IEnumerator Spawn()
    {
        ///Will continue untill stopAtLimit is true AND unit count is not less then limit
        while (!(spawningType == Spawning.StopAtLimit && limit <= units.Count) || limit < 0)
        {   ///Loops and removes all objects that have been destroyed outside this function
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i] == null)
                {
                    units.RemoveAt(i);
                    i--;
                }
            }
            /// Will skip if waitAtLimit is true AND unit count is not less then limit
            if (!(spawningType == Spawning.WaitAtLimit && limit <= units.Count) || limit < 0)
            {

                if (spawningType == Spawning.DespawnAtLimit && limit <= units.Count && limit > 0)
                {
                    while (limit <= units.Count)
                    {
                        if (despawnTimerBool)
                            yield return new WaitForSeconds(despawnTimer);

                        Destroy(units[0]);
                        units.RemoveAt(0);
                    }

                }
                GameObject go = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
                go.name = name + go.name + index;
                units.Add(go);
                index++;
            }

            yield return new WaitForSeconds(timer);
        }
    }

    /// <summary>
    /// StopAtLimit: When limit is reached no more objects will spawn from this script
    /// WaitAtLimit: When limit is reached will wait untill objects have been destroyed outside this sript
    /// DespawnAtLimit: When limit is reached will despawn oldes object from this script
    /// NoLimit: Will ignor limit set
    /// </summary>
    public enum Spawning {NoLimit, StopAtLimit,WaitAtLimit,DespawnAtLimit};
   // [SerializeField]
    public Spawning spawningType = Spawning.NoLimit;

    /// <summary>
    /// Seconds per spawn.
    /// </summary>
    public float timer = 1;
    public bool despawnTimerBool = false;

    public float despawnTimer = 1f;
    /// <summary>
    /// Prefab to be spawned
    /// </summary>
    public GameObject prefab;
    /// <summary>
    /// Max number of spawned(If despawnAtLimit is true)
    /// </summary>
    public int limit = 1;
    int index;

    /// <summary>
    /// storage and queue for each unit spawned(if despawnedAtLimit is true)
    /// </summary>
    private List<GameObject> units = new List<GameObject>();
    
}

//Custom Inspector
[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var spawner = (Spawner)target;

        spawner.prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", spawner.prefab, typeof(GameObject),true);

        spawner.spawningType = (Spawner.Spawning)EditorGUILayout.EnumPopup("Limit Options", spawner.spawningType);

        if (spawner.spawningType != Spawner.Spawning.NoLimit)
        {
            spawner.limit = EditorGUILayout.IntField("Spawn Limit",spawner.limit);
            if (spawner.spawningType == Spawner.Spawning.DespawnAtLimit)
            {
                spawner.despawnTimerBool = EditorGUILayout.Toggle("Despawn Timer" , spawner.despawnTimerBool);
            
                if(spawner.despawnTimerBool)
                spawner.despawnTimer = EditorGUILayout.FloatField("Despawn Timer", spawner.despawnTimer);
            }
        }
        spawner.timer = EditorGUILayout.FloatField("Spawn Timer", spawner.timer);

    }


}