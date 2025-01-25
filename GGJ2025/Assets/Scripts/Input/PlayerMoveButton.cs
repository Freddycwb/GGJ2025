using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMoveButton : MonoBehaviour, IInputAction
{
	[SerializeField] private int id;

	public bool buttonDown {
		get {
			bool gamepad = false;
			if (id < Gamepad.all.Count) {
				gamepad = Gamepad.all[id].rightTrigger.wasPressedThisFrame || Gamepad.all[id].leftTrigger.wasPressedThisFrame;
			}
			return Input.GetKeyDown(KeyCode.Space) || gamepad;
		}
	}

	public bool buttonHold {
		get {
			bool gamepad = false;
			if (id < Gamepad.all.Count) {
				gamepad = Gamepad.all[id].rightTrigger.isPressed || Gamepad.all[id].leftTrigger.isPressed;
			}
			return Input.GetKey(KeyCode.Space) || gamepad;
		}
	}

	public bool buttonUp {
		get {
			bool gamepad = false;
			if (id < Gamepad.all.Count) {
				gamepad = Gamepad.all[id].rightTrigger.wasReleasedThisFrame || Gamepad.all[id].leftTrigger.wasReleasedThisFrame;
			}
			return Input.GetKeyUp(KeyCode.Space) || gamepad;
		}
	}
}
