namespace UnityPractice_FSharpScripts
open UnityEngine

/// Script that handles bullet behaviour of basic weapon
type BasicBullet() = 
    inherit MonoBehaviour()

    [<SerializeField>]
    let mutable velocity = 10.0f // initial velocity when spawned
    [<SerializeField>]
    let mutable damage = 10.0f // how much damage this deals on contact

    // Sets the velocity of the rigidbody
    member this.Start() = 
        this.GetComponent<Rigidbody2D>().velocity <-
            Vector2( this.transform.up.x, this.transform.up.y ) * velocity 

    // Tells asteroids to take damage when they enter this object's trigger, then goes boom
    member this.OnTriggerEnter2D ( other:Collider2D ) =
        if other.gameObject.CompareTag( "Asteroid" ) then
            other.SendMessage( "TakeDamage", damage, SendMessageOptions.DontRequireReceiver )
            Object.Destroy( this.gameObject )