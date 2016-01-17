namespace UnityPractice_FSharpScripts
open UnityEngine

/// Script that moves the player around and fires the weapon.
type PlayerController() = 
    inherit MonoBehaviour()

    [<SerializeField>]
    let mutable turn_rate = 250.0f // how fast it turns
    [<SerializeField>]
    let mutable thrust_rate = 2.0f // how fast it accelerates

    [<SerializeField>]
    [<Range(0.0f,1.0f)>] // creates a slider in the editor
    let mutable stop_rate = 0.10f // lerp amount when decelerating
    [<SerializeField>]
    let mutable max_speed = 10.0f // 

    let mutable velocity = Vector3.zero

    //member this.Start() = 
      //  this.transform.
    /// Handles the weapons
    //member this.Update() = 
      //  GameObject.
     
    /// Handles the motion of the player controller.
    member this.FixedUpdate() =
        // get the input, and scale 
        let turn = Input.GetAxis( "Horizontal" ) * turn_rate * Time.fixedDeltaTime
        let thrust = Input.GetAxis( "Vertical" ) * thrust_rate * Time.fixedDeltaTime

        // rotates the object around the z axis
        Vector3( 0.0f, 0.0f, turn ) 
        |> this.transform.Rotate

        // calculates the current velocity, then translates the ship based on the velocity
        //    Yes, this is somewhat emulating what rigidbody does, but rigidbody brings a lot of
        //    extra baggage we don't need. Specifically, this seperates angular and linear velocities
        if thrust >= 0.0f then
            velocity <- velocity + thrust * this.transform.up
        else
            velocity <- Vector3.Lerp( velocity, Vector3.zero, stop_rate )

        if( velocity.magnitude > max_speed**2.0f ) then
            velocity <- velocity.normalized * max_speed

        this.transform.Translate( velocity * Time.fixedDeltaTime, Space.World )
