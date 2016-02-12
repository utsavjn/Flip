using UnityEngine;
using System.Collections;


public class AutoFire : MonoBehaviour
{
    private bool hasSpawn;
    private EnemyScript EnemyScript;
    private WeaponScript[] weapons;

    void Awake()
    {
        weapons = GetComponentsInChildren<WeaponScript>();

        EnemyScript = GetComponent<EnemyScript>();
    }

    void Start()
    {
        hasSpawn = false;
        GetComponent<Collider2D>().enabled = false;
        EnemyScript.enabled = false;
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = false;
        }
    }

    void Update()
    {
        if (hasSpawn == false)
        {
            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            foreach (WeaponScript weapon in weapons)
            {
                if (weapon != null && weapon.enabled && weapon.CanAttack)
                {
                    weapon.Attack(true);
                    SoundEffectsHelper.Instance.MakeEnemyShotSound();
                }
            }
            
            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
    }
    private void Spawn()
    {
        hasSpawn = true;
        GetComponent<Collider2D>().enabled = true;
        EnemyScript.enabled = true;
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = true;
        }
    }
}
