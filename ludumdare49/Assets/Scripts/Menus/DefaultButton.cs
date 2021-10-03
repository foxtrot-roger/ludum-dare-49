using UnityEngine;
using UnityEngine.UI;

public class DefaultButton : MonoBehaviour
{
    public KeyCode KeyCode;
    Button Button;

    private void Start()
    {
        Button = GetComponent<Button>();
        Button.GetComponentInChildren<Text>().text += $" [{KeyCode}]";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode))
            Button.onClick.Invoke();
    }
}
