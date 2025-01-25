using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class RumbleControl : MonoBehaviour
{
    [SerializeField] private int id;

    public void Rumble()
    {
        Gamepad.all[id].SetMotorSpeeds(0.123f, 0.234f);
    }
}
