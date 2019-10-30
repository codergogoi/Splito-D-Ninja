using UnityEngine;
using System.Collections;









public class levelControll : MonoBehaviour {






    public bool isHealthRefill;
    public bool isAmmoRefill;

    public int CurrentHealth;

    private int BulletCount;
    private int DamageCount;

    void EventControll() {
        
        if (isHealthRefill) {

            if (CurrentHealth > 50) {
                    
                    BulletCount += 1;
                    CurrentHealth -= 50;                            
            }

        } else if (isAmmoRefill) {

            if (CurrentHealth > 50) {

                    DamageCount += 1;
                    CurrentHealth -= 50;

            }
         
        }

    }























}