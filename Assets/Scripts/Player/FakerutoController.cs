using UnityEngine;

public class FakerutoController : Hitable
{
    private Vector3 m_GroundNormal;
    private PlayerController playerController;

    private bool isInvincible = false;

    [SerializeField]
    private float blinkInterval = 0.1f;
    private float currentBlinkInterval = 0.0f;

    private void Update()
    {
        if (isInvincible)
        {
            if (currentBlinkInterval <= 0.0f)
            {
                Renderer mesh = GetComponent<MeshRenderer>();
                mesh.enabled = !mesh.enabled;
                currentBlinkInterval = blinkInterval;
            }
            else
            {
                currentBlinkInterval -= Time.deltaTime;
            }
        }
    }

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

        RaycastHit hitInfo;
        if (!Physics.Raycast(playerController.transform.position, move, out hitInfo, 1.5f))
        {
            playerController.transform.Translate(move);
        }
    }

    public override bool OnHit(GameObject origin)
    {
        return playerController.OnHit(origin);
    }

    public void SetInvincible(bool invincible)
    {
        isInvincible = invincible;
        Renderer mesh = GetComponent<MeshRenderer>();
        mesh.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        TurretTeleport turret = other.gameObject.GetComponent<TurretTeleport>();
        Shield shield = other.gameObject.GetComponent<Shield>();
        if (turret != null || shield != null)
        {
            OnHit(null);
        }
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
}
