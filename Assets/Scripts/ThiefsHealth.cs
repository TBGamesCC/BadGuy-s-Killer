using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefsHealth : MonoBehaviour
{
    private float StartHealth;
    private float CurrentHealth;
    public bool IsDead;
    void Awake()
    {
        StartHealth = 100;
        CurrentHealth = StartHealth;
       
    }
    void OnEnable()
    {
        GameEvents.ThiefDie += OnDie;
    }
    void OnDestroy()
    {
        GameEvents.ThiefDie -= OnDie;
    }
    void OnTriggerEnter(Collider other)
    {
        var doDamage = other.gameObject.GetComponentInChildren<Damage>();
        var moeny = other.gameObject.GetComponentInParent<Moeny>();
        if (doDamage != null)
        {
            Damage(doDamage.DoDamage);
        }
        
    }
  
    private void Damage(float damage)
    {
        CurrentHealth -= damage;
        
    }
    void Update()
    {
        if (CurrentHealth > 0)
        {
            GameEvents.ThiefDie?.Invoke(new GameEvents.ThifeData { IsDie = false });
        }
        else
        {
            GameEvents.ThiefDie?.Invoke(new GameEvents.ThifeData { IsDie = true });
        }
        if (IsDead)
        {
            CurrentHealth = 0;
            Destroy(gameObject);
        }
    }
    private void OnDie(GameEvents.ThifeData thifdata)
    {     
        IsDead = thifdata.IsDie;
    }
}
