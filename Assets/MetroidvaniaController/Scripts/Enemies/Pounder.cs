using UnityEngine;

public class Pounder : MonoBehaviour
{

    [SerializeField] float upMoveSpeed = 8f; // Speed Up
    [SerializeField] float downMoveSpeed = 8f; // Speed Down
    [SerializeField] float upDownSwitch = 4f; // 

    private bool movingUp = true;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        // Upwards movement
        if (movingUp)
        {
            transform.Translate(Vector3.up * upMoveSpeed * Time.deltaTime);
            timer += Time.deltaTime;

            if (timer >= upDownSwitch)
            {
                // Switch movement and reset timer
                movingUp = false;
                timer = 0f; 
            }
        }

        // Downwards movement
        else
        {
            transform.Translate(Vector3.down * downMoveSpeed * Time.deltaTime);
            timer += Time.deltaTime;

            if (timer >= upDownSwitch)
            {
                // Switch movement and reset timer
                movingUp = true; // Switch to upward movement
                
                timer = 0f; // Reset timer
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<CharacterController2D>().ApplyDamage(2f, transform.position);
			Debug.Log("Collision");
		}
		
	}
}
