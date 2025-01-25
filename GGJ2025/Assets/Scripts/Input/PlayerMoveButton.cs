using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMoveButton : MonoBehaviour, IInputAction
{
	public bool buttonDown {
		get {
			bool gamepad = false;
			if (Gamepad.current != null) {
				gamepad = Gamepad.current.rightTrigger.wasPressedThisFrame || Gamepad.current.leftTrigger.wasPressedThisFrame;
			}
			return Input.GetKeyDown(KeyCode.Space) || gamepad;
		}
	}

	public bool buttonHold {
		get {
			bool gamepad = false;
			if (Gamepad.current != null) {
				gamepad = Gamepad.current.rightTrigger.isPressed || Gamepad.current.leftTrigger.isPressed;
			}
			return Input.GetKey(KeyCode.Space) || gamepad;
		}
	}

	public bool buttonUp {
		get {
			bool gamepad = false;
			if (Gamepad.current != null) {
				gamepad = Gamepad.current.rightTrigger.wasReleasedThisFrame || Gamepad.current.leftTrigger.wasReleasedThisFrame;
			}
			return Input.GetKeyUp(KeyCode.Space) || gamepad;
		}
	}
}
