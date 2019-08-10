using UnityEngine;

public class PlayerController : Hitable
{
    public float MovementMultiplier = 0.5f;

    private Transform Cam;
    private Vector3 CamForward;
    private Vector3 Movement;
    private FakerutoController Avatar;

    private void Start()
    {
        Cam = Camera.main.transform;
        Avatar = GetComponentInChildren<FakerutoController>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        CamForward = Vector3.Scale(Cam.forward, new Vector3(1, 0, 1)).normalized;
        Movement = v * CamForward + h * Cam.right;

        Avatar.Move(Movement * MovementMultiplier);
    }
    
    public override void OnHit(GameObject origin)
    {
        if (origin != gameObject)
        {
            gameObject.SetActive(false);
        }
    }
}