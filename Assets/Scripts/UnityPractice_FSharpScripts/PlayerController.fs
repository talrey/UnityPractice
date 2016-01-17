namespace UnityPractice_FSharpScripts
open UnityEngine


/// Script that moves the player around and fires the weapon.
type PlayerController() = 
    inherit MonoBehaviour()

    [<SerializeField>]
    let mutable turnRate = 250.0f // how fast it turns
    [<SerializeField>]
    let mutable thrustRate = 2.0f // how fast it accelerates

    [<SerializeField>]
    [<Range(0.0f,1.0f)>] // creates a slider in the editor
    let mutable stopRate = 0.10f // lerp amount when decelerating
    [<SerializeField>]
    let mutable maxSpeed = 10.0f // clamps velocity.magnitude to this value

    let mutable velocity = Vector3.zero

    [<DefaultValue>]
    val mutable weaponController : UnityPractice_FSharpScripts.WeaponController

    /// Retreive the weapon Controller component
    member this.Start() = 
        this.weaponController <- this.GetComponent<UnityPractice_FSharpScripts.WeaponController>()
    /// Handles the weapons
    member this.Update() = 
        if Input.GetButtonDown( "Fire1" ) then 
            this.weaponController.Fire() |> ignore
        if Input.GetButtonDown( "Fire2" ) then
            this.weaponController.CycleUp() |> ignore
     
    /// Handles the motion of the player controller.
    member this.FixedUpdate() =
        // get the input, and scale 
        let turn = Input.GetAxis( "Horizontal" ) * turnRate * Time.fixedDeltaTime
        let thrust = Input.GetAxis( "Vertical" ) * thrustRate * Time.fixedDeltaTime

        // rotates the object around the z axis
        Vector3( 0.0f, 0.0f, turn ) 
        |> this.transform.Rotate

        // calculates the current velocity, then translates the ship based on the velocity
        //    Yes, this is somewhat emulating what rigidbody does, but rigidbody brings a lot of
        //    extra baggage we don't need. Specifically, this seperates angular and linear velocities
        if thrust >= 0.0f then
            velocity <- velocity + thrust * this.transform.up
        else
            velocity <- Vector3.Lerp( velocity, Vector3.zero, stopRate )

        if( velocity.magnitude > maxSpeed**2.0f ) then
            velocity <- velocity.normalized * maxSpeed

        this.transform.Translate( velocity * Time.fixedDeltaTime, Space.World )
