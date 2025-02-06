using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);

    private void LateUpdate()
    {
        transform.position = target.position + offset;

    }
}

