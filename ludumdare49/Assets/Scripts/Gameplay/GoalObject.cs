using UnityEngine;

public class GoalObject : MonoBehaviour
{
    Game game;

    private void Start()
    {
        game = FindObjectOfType<Game>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        game.VictoryMenu();
    }
}
