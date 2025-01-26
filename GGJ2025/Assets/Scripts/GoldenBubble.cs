using UnityEngine;

public class GoldenBubble : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float introSpeed;
    [SerializeField] private GameObject closestTarget;
    [SerializeField] private float escapeSpeed;
    private bool onArea;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!onArea)
        {
            rb.AddForce(-transform.position.normalized * introSpeed);
        }
        if (closestTarget != null)
        {
            Vector2 dir = transform.position - closestTarget.transform.position;
            rb.AddForce(dir.normalized * escapeSpeed);
        }
    }

    public void SetClosestTarget(GameObject value)
    {
        if (closestTarget != null)
        {
            if (Vector2.Distance(closestTarget.transform.position, transform.position) > Vector2.Distance(value.transform.position, transform.position))
            {
                closestTarget = value;
            }
        }
        else
        {
            closestTarget = value;
        }
    }

    public void SetOnArea()
    {
        onArea = true;
    }
}
