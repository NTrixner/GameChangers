using UnityEngine;
using UnityEngine.UI;

public class TargetUI : MonoBehaviour
{
    public Text targetText;

    private void OnGUI()
    {
        targetText.text = GameMode.Instance.GetProgressDescription();
    }
}
