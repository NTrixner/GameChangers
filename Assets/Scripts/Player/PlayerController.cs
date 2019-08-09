using UnityEngine;

public class PlayerController : MonoBehaviour
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

        if (Cam != null)
        {
            CamForward = Vector3.Scale(Cam.forward, new Vector3(1, 0, 1)).normalized;
            Movement = v * CamForward + h * Cam.right;
        }
        else
        {
            Movement = v * Vector3.forward + h * Vector3.right;
        }

        Avatar.Move(Movement * MovementMultiplier);
    }


}