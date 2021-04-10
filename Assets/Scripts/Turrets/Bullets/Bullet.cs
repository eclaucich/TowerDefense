using UnityEngine;

/*

Base class for a bullet fired by a turret

*/

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform target = null;
    private int damage;

    /// Moves towards the target until it reachs it
    void Update()
    {
        if(GameController.instance.gameState == GameController.GameState.playing)
        {
            if(target!=null)
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
            else
                Destroy(this.gameObject);
        }
    }

    public void SetTarget(Transform target_, int damage_)
    {
        target = target_;
        damage = damage_;
    }

    /// Damage the enemy when hitted and destroys itself
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().Damage(damage);
            Instantiate(GameController.instance.bulletHitParticle, other.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
