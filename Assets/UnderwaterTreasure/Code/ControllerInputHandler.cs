using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInputHandler : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] PlayerBehaviour player;

    public void OnMove(InputAction.CallbackContext value)
    {
        player.OnMove(value);
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        player.OnJump(value);
    }

    public void OnFire(InputAction.CallbackContext value)
    {
        player.OnFire(value);
    }

    public void OnInvinsible(InputAction.CallbackContext value)
    {
        player.OnInvisible(value);
    }

    public void OnHologram(InputAction.CallbackContext value)
    {
        player.OnHologram(value);
    }
}
