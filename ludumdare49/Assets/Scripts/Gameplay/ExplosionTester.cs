using UnityEngine;

public class ExplosionTester : MonoBehaviour
{
    public Camera Camera;
    public float ExplosionForce;


    private void Start()
    {
        GetComponent<LevelLoader>().LoadLevel(0);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var position = (Vector2)Camera.ScreenToWorldPoint(Input.mousePosition);

            MyPhysics.AddLinearExplosionForce(position, ExplosionForce, 100);
            //foreach (var item in FindObjectsOfType<Rigidbody2D>())
            //{
            //    item.AddForce((item.position - position) * ExplosionForce);
            //}
        }
    }
}
