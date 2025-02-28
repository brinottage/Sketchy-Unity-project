using System.Collections;
using UnityEngine;



public class TurretBlock : MonoBehaviour
{

    public TurretBullet TurretBulletPrefab;  // Prefab of the turret bullet
    public float range = 10f;
    public float cooldown = 0f;
    private GameObject target;

    void Update()
    {

        Debug.Log(cooldown);

        // Finds the player
        target = GameObject.FindWithTag("Player"); // Assuming the player has the "Player" tag
        
        // Checks whether the player in the set range of the TurretBlock
        if (Vector3.Distance(transform.position, target.transform.position) <= range)
        {
            // Decrease cooldown timer
            cooldown -= Time.deltaTime;

            // If the cooldown has reached zero, fire a bullet
            if (cooldown <= 0f)
            {
                BulletSpawn();
                cooldown = 2f;  // Reset the timer
            }
        }
    }


    // Spawns Bullet, and fires it towards the player
    void BulletSpawn()
    {
        TurretBullet bullet = Instantiate(TurretBulletPrefab, transform.position, Quaternion.identity);
        Vector3 direction = (target.transform.position - transform.position).normalized;

       
        bullet.SetBulletDirection(direction);
    }

}
