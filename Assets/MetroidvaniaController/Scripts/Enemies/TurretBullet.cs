using UnityEngine;

public class TurretBullet : MonoBehaviour
{

    private Vector3 direction;

    [SerializeField] float speed = 10f;

    void Start()
    {
        // after 6 secs, the bullet self-destructs
        Destroy(gameObject, 6f); 
    }


    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Bullet direction
    public void SetBulletDirection(Vector3 directionInput)
    {
        direction = directionInput;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Damage player
            collision.gameObject.GetComponent<CharacterController2D>().ApplyDamage(2f, transform.position);
            Debug.Log("Collision with Player");
            Destroy(gameObject);
        }
    }
}
