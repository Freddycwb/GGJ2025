using UnityEngine;
using UnityEngine.Events;

public class PlayerMoveEvents : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private UnityEvent dash;
    [SerializeField] private UnityEvent charge;

    private void Start()
    {
        playerMovement.dash += Dash;
        playerMovement.charge += Charge;
    }

    private void Dash()
    {
        if (dash != null)
        {
            dash.Invoke();
        }
    }

    private void Charge()
    {
        if (charge != null)
        {
            charge.Invoke();
        }
    }
}
