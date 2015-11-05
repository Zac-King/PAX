using UnityEngine;
using System.Collections;

public class AutoCannon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePref;
    [SerializeField]
    private float delay;


    float timer = 0;


    // Update is called once per frame
    void Update()
    {
        
        if(delay<timer)
        {
            Instantiate(projectilePref, transform.position, transform.rotation);

            timer = 0;
        }

        timer += Time.deltaTime;

    }
}
