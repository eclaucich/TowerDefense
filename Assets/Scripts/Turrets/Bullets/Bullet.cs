using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform target = null;
    private int damage;

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
