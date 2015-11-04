/// <summary>
/// Developed by: Quinton "Kiro" Baudoin.
/// 
/// Purpose: To act as a health counter.
/// 
/// Usage: Attach to desired gameobject and use the Messanger System
///         to broadcast "takedamage", with name of gameobject and this
///         script will check to see if it got hit and then reduce health.
///         When health hits 0 or less "playerdied" with name of gameobject this is
///         attached to.
/// 
/// </summary>
///////////////////////////////////


using UnityEngine;
using System.Collections;



public class HealthStats : MonoBehaviour
{
    [SerializeField]
    protected int _health = 3;
    /// <summary>
    /// public
    /// Getter/Setter for _health
    /// </summary>
    public int health
    {
        get { return _health; } //returns _health
        protected set           // Protected Set
        {          
           _health = value;      //Sets _health to Value

            if (health <= 0)     //If health is less then or equal to 0
                OnDead();        //Triggers OnDead()
        }

     }

    

    protected virtual void TakeDamage(string message)
    {
        if (message == name) // Checks to see if message is equal to gameObject.name
        { health--; }       // reduces health by 1
    }

    protected virtual void OnDead()
    {
        Messenger.Broadcast("playerdied", name); //Broacasts "playerdied" with gameObject.name
    }

    public virtual void OnEnable()
    {
        Messenger.AddListener<string>("takedamage", TakeDamage); //AddListener of "takedamage" with TakeDamage function
        Messenger.MarkAsPermanent("takedamage");
    }
    public virtual void OnDisable()
    {
        Messenger.RemoveListener<string>("takedamage", TakeDamage); //Removes listener of "takedamage" with TakeDamage function
    }

}
