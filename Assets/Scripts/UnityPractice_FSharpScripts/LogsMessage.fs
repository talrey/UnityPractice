namespace UnityPractice_FSharpScripts
open UnityEngine

type LogsMessage() =
    inherit MonoBehaviour()

    member this.TakeDamage( dmg:float ) = 
        Debug.Log( "I've taken " + dmg.ToString() + " damages" )