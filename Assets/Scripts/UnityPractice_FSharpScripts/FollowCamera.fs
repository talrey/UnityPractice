namespace UnityPractice_FSharpScripts
open UnityEngine

type FollowCamera() = 
    inherit MonoBehaviour()

    [<SerializeField>]
    let mutable camera_offset = Vector3.zero

    // Fields that can't be assigned a default value require this in F#
    [<SerializeField>] [<DefaultValue>]
    val mutable to_follow : GameObject

    // Initialize previously unassignable fields
    member this.Start() = 
        this.to_follow <- GameObject.FindGameObjectWithTag( "Player" )

    // every physics cycle, have the camera follow the game object
    member this.FixedUpdate() = 
        this.transform.position <- this.to_follow.transform.position + camera_offset