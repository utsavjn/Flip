using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthScript : MonoBehaviour
{

    public int HitPoints = 1;
    private int score = 1;
    

    public bool isEnemy = true;
    

    void OnTriggerEnter2D(Collider2D collider)
    {

        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();

        if (shot != null)
        {
            if (shot.isEnemyShot != isEnemy)
            {
                
                HitPoints -= shot.damage;
              
                Destroy(shot.gameObject);
                
                if (HitPoints <= 0)
                {
                    SpecialEffectsHelper.Instance.Explosion(transform.position);
                    SoundEffectsHelper.Instance.MakeExplosionSound();
                    Score.score += score;
                   Destroy(gameObject);
                    
                }
            }
        }
    }
}
