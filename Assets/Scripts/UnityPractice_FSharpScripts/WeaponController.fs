namespace UnityPractice_FSharpScripts
open UnityEngine

/// Script that handles the weapon selection and firing
// player input has been encapsulated away. Needs to be attached to a player Controller
type WeaponController() = 
    inherit MonoBehaviour()

    [<SerializeField>][<DefaultValue>]
    val mutable bulletList : GameObject[]

    [<SerializeField>]
    let mutable currentWeapon = 0

    [<SerializeField>]
    let mutable weaponOffset = 1.0f

    member this.CycleUp() = 
        currentWeapon <- ( currentWeapon + 1 ) % this.bulletList.Length

    member this.CycleDown() = 
        currentWeapon <- ( currentWeapon - 1 ) % this.bulletList.Length

    member this.Fire() =
        let wo = this.bulletList.[currentWeapon]
        let po = this.transform.position + ( this.transform.up * weaponOffset )
        let ro = this.transform.rotation
        GameObject.Instantiate( wo, po , ro )