using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakerutoController : MonoBehaviour
{
    private Vector3 m_GroundNormal;

    private void OnEnable()
    {
        InvokeRepeating("UpdateGroundNormal", 0.0f, 0.5f);
    }

    private void OnDisable()
    {
        CancelInvoke("UpdateGroundNormal");
    }

    public void Move(Vector3 move)
    {
        if (move.magnitude > 1f)
        {
            move.Normalize();
        }

        move = transform.InverseTransformDirection(move);
        move = Vector3.ProjectOnPlane(move, m_GroundNormal);

        transform.Translate(move);
    }

    private Vector3 UpdateGroundNormal()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, 0.1f))
        {
            m_GroundNormal = hitInfo.normal;
        }

        return m_GroundNormal;
    }
}
