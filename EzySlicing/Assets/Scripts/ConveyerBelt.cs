using UnityEngine;
public class ConveyerBelt : MonoBehaviour
{
    public enum BeltForceMode
    {
        Push,
        Pull
    }
    public enum RelativeDirection
    {
        Up,
        Down,
        Left,
        Right,
        Forward,
        Backward
    }
    public float velocity;

    public RelativeDirection direction = RelativeDirection.Down;
    public BeltForceMode beltMode = BeltForceMode.Push;

    private Rigidbody body;
    private Vector3 pos;

    public void Awake()
    {
        body = GetComponent<Rigidbody>();
        pos = transform.position;
    }

    public void FixedUpdate()
    {
        if (body != null && beltMode == BeltForceMode.Pull)
        {
            Vector3 movement = Time.fixedDeltaTime * velocity * GetDirection();
            transform.position = pos - movement;
            body.MovePosition(pos);
        }
    }

    public void OnCollisionStay(Collision other)
    {
        if (other.rigidbody != null && !other.rigidbody.isKinematic && beltMode == BeltForceMode.Push)
        {
            Vector3 movement = Time.deltaTime * velocity * GetDirection();
            other.rigidbody.MovePosition(other.transform.position + movement);
        }
    }

    public Vector3 GetDirection()
    {
        switch (direction)
        {
            case RelativeDirection.Up:
                return transform.up;
            case RelativeDirection.Down:
                return -transform.up;
            case RelativeDirection.Left:
                return -transform.right;
            case RelativeDirection.Right:
                return transform.right;
            case RelativeDirection.Forward:
                return transform.forward;
            case RelativeDirection.Backward:
                return -transform.forward;
        }
        return transform.forward;
    }
}