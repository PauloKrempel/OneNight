using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance{
        get{
            return _instance;
        }
    }
    private PlayerMoveScript playerMoveScript;
    private void Awake() {
        if(_instance != null && _instance != this){
            Destroy(this.gameObject);
        }
        else{
            _instance = this;
        }
        playerMoveScript = new PlayerMoveScript();
    }
    private void OnEnable() {
        playerMoveScript.Enable();
    }
    private void OnDisable() {
        playerMoveScript.Disable();
    }

    public Vector2 GetPlayerMovement(){
        return playerMoveScript.Player.Movement.ReadValue<Vector2>();
    }
    public Vector2 GetMouseDelta(){
        return playerMoveScript.Player.Look.ReadValue<Vector2>();
    }
    public bool PlayerJumpedThisFrame(){
        return playerMoveScript.Player.Jump.triggered;
    }
}
