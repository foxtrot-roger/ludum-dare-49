using UnityEngine;

public class FailObject : MonoBehaviour
{
    Game game;

    private void Start()
    {
        game = FindObjectOfType<Game>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        game.FailureMenu();
    }
}