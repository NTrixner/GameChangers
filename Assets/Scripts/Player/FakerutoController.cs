using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakerutoController : MonoBehaviour
{
    private Vector3 m_GroundNormal;
    private Transform parentTransform;

    private void OnEnable()
    {
        InvokeRepeating("UpdateGroundNormal", 0.0f, 0.5f);
        parentTransform = transform.parent;
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

        
        move = parentTransform.InverseTransformDirection(move);
        move = Vector3.ProjectOnPlane(move, m_GroundNormal);

        transform.rotation = Quaternion.LookRotation(move, Vector3.up);

        parentTransform.Translate(move);
    }

    private Vector3 UpdateGroundNormal()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(parentTransform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, 0.1f))
        {
            m_GroundNormal = hitInfo.normal;
        }

        return m_GroundNormal;
    }
}
