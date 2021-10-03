using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Input")]
public class InputConfiguration : ScriptableObject
{
    public KeyCode Left = KeyCode.Q;
    public KeyCode Right = KeyCode.D;
    public KeyCode Jump = KeyCode.Space;

    public float ReadHorizontal()
        => (Input.GetKey(Left) ? -1 : 0) + (Input.GetKey(Right) ? 1 : 0);
    public bool ReadJump()
        => Input.GetKeyDown(Jump);
}
