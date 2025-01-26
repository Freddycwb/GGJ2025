using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class RumbleControl : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private Vector2 motorSpeed;
    [SerializeField] private float rumbleTime;
    [SerializeField] private float rumbleTimeOnDamageRumble;

    private Coroutine coroutine;

    public void Rumble()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(RumbleRoutine(motorSpeed));
    }

    public void Rumble(IntVariable value)
    {
        Vector2 basic = motorSpeed * value.Value;
        rumbleTime = rumbleTimeOnDamageRumble * value.Value;
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(RumbleRoutine(basic));
    }

    private IEnumerator RumbleRoutine(Vector2 motorSpeed)
    {
        if (Gamepad.all[id] != null)
        {
            Gamepad.all[id].SetMotorSpeeds(motorSpeed.x, motorSpeed.y);
            yield return new WaitForSeconds(rumbleTime);
            Gamepad.all[id].SetMotorSpeeds(0, 0);
        }
    }

    private void OnDestroy()
    {
        if (Gamepad.all[id] == null)
        {
            return;
        }
        Gamepad.all[id].SetMotorSpeeds(0, 0);
    }
}
