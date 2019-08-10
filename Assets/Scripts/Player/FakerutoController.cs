using UnityEngine;

public class FakerutoController : Hitable
{
    private Vector3 m_GroundNormal;
    private PlayerController playerController;

    private void OnEnable()
    {
        InvokeRepeating("UpdateGroundNormal", 0.0f, 0.5f);
        playerController = GetComponentInParent<PlayerController>();
    }

    private void OnDisable()
    {
        CancelInvoke("UpdateGroundNormal");
    }

    public void Move(Vector3 move)
    {
        if (move.sqrMagnitude == 0f)
        {
            return;
        }

        if (move.magnitude > 1f)
        {
            move.Normalize();
        }

        
        move = playerController.transform.InverseTransformDirection(move);
        move = Vector3.ProjectOnPlane(move, m_GroundNormal);

        transform.rotation = Quaternion.LookRotation(move, Vector3.up);

        playerController.transform.Translate(move);
    }

    private Vector3 UpdateGroundNormal()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(playerController.transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, 0.1f))
        {
            m_GroundNormal = hitInfo.normal;
        }

        return m_GroundNormal;
    }

    public override void OnHit(GameObject origin)
    {
        playerController.OnHit(origin);
    }
}
