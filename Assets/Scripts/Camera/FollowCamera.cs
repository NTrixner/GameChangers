using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float damping = 0.01f;

    private Transform target;
    private Vector3 m_Offset;
    private Vector3 m_LastTargetPosition;
    private Vector3 m_CurrentVelocity;

    private void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;

        m_LastTargetPosition = target.position;
        m_Offset = (transform.position - target.position);
        transform.parent = null;
        m_LastTargetPosition = target.transform.position;
    }

    private void Update()
    {
        Vector3 nextTargetPos = target.position + m_Offset;

        transform.position = Vector3.SmoothDamp(transform.position, nextTargetPos, ref m_CurrentVelocity, damping);

        m_LastTargetPosition = target.position;
    }
}
