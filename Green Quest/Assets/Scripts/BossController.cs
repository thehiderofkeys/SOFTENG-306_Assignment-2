using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * BossController: Handles the Boss specific functionality, seperate from the level 2 enemy.
 *   - Handles the stunning and damage animation for the Boss
 *   - Handles the various smoke attack.
 *     - Each attack is a Serializable object, able to be modified in frequency and type
 */
public class BossController : MonoBehaviour
{
    /** Attack: Serialixable data class, able to be modified in the Unity editor to encourage flexiblity.
     *   - Each attack has a type and the probability, and holds a static last attak, to enable a cooldown.
     */
    [System.Serializable]
    public class Attack
    {
        public Transform AttackPrefab; //The Smoke project tile template to spawn.
        public float probability; // The probability of the attack occuring must add to 1.
        [HideInInspector]
        public static float LastAttack = -1; //Time of last attack
    }
    public float AttackCooldown; //How long to wait before next attack
    public Attack[] AttackList; //The list of attack moves available to the Boss
    public int HealthRemaing; 
    public UnityEvent OnDeath; //What event to trigger when killed.
    public GameObject Smog;
    public static BossController instance; //Static reference to the singleton.
    
    void Start()
    {
        instance = this; //Set the instance reference.
    }

    void Update()
    {
        // Attack functionality
        if (!GetComponent<EnemyController>().stunned) //Attacks are disable when stunned.
        {
            float prob = Random.value; //Choose the attack. random number between 0 - 1 (inclusive)
            foreach (Attack attack in AttackList)
            {
                if (Attack.LastAttack < 0 || Time.time - Attack.LastAttack > AttackCooldown) //If the attack is available.
                {
                    if (prob > 0 && prob < attack.probability) //If the probability is within 0 - attack probability range.
                    {
                        Attack.LastAttack = Time.time;  //Set time for cooldown
                        Instantiate(attack.AttackPrefab, transform.position + Vector3.up, Quaternion.identity); //Spawn the projectile
                    }
                }
                prob -= attack.probability; //Normalise the probability between 0 - next range.
            }
        }
    }

    /** OnHit: Handles when the boss takes damage.
     */
    public void OnHit()
    {
        //If Boss has lives remaining
        if (HealthRemaing > 1)
        {
            HealthRemaing--; 
            GetComponent<EnemyController>().LaunchPlayer(12*Vector2.up); //Launch the player up for dramatic effect
            SetStunned(5f); //Stun the Boss to allow player to escape
        }
        else
        {
            OnDeath.Invoke(); //Kill the boss
        }
    }
    /** SetStunned: Starts the croutines handling the animation for when teh Boss takes damage.
     *      duration - How long to stunn the boss when hit
     */
    public void SetStunned(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(StunAnimation(duration));
        StartCoroutine(Respawn(duration));
    }
    /**SetVolnurable: Starts the coroutines handling disabling the shields.
     *      duration - how long the boss should be volnurable.
     */
    public void StartVolnurable(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(Volunarable(duration));
    }
    /** StunAnimation: Handles the stunned animation.
     *      duration - how long to loop the animation.
     */
    private IEnumerator StunAnimation(float duration)
    {
        GetComponent<EnemyController>().stunned = true; //Stop the enemy attacks
        Color currColor; 
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>(); //Gets the visuals
        renderer.color = Color.red; //Flash red for 0.2s
        yield return new WaitForSeconds(0.2f);
        renderer.color = Color.white;
        for (int i = 0; i * 0.4 < duration; i++)
        {   //Repeatedly flash 
            currColor = renderer.color;
            currColor.a = 0.8f; //Go slightly translucent
            renderer.color = currColor;
            yield return new WaitForSeconds(0.2f);
            currColor = renderer.color;
            currColor.a = 1f;
            renderer.color = currColor;
            yield return new WaitForSeconds(0.2f);
        }
        GetComponent<EnemyController>().stunned = false;//Resume attacks and movement

        GetComponentInChildren<Animator>().enabled = true; //Restart the movement anamiation.
    }
    /** Respawn: Handles the invincibility duration
     *      duration - how long to stop collision with the player
     */
    private IEnumerator Respawn(float duration)
    {
        gameObject.layer = LayerMask.NameToLayer("IgnorePlayer");
        yield return new WaitForSeconds(duration);
        gameObject.layer = LayerMask.NameToLayer("Enemy");
        GetComponent<EnemyController>().Invincible = true;
        Smog.SetActive(true);
    }
    /** Volnurable: Handles diabling the shield for a period of time
     *      duration - how long to disable the shield
     */
    private IEnumerator Volunarable(float duration)
    {
        GetComponent<EnemyController>().Invincible = false;
        GetComponent<EnemyController>().stunned = true;
        GetComponentInChildren<Animator>().enabled = false;
        Smog.SetActive(false);
        yield return new WaitForSeconds(duration);
        GetComponent<EnemyController>().stunned = false;
        GetComponent<EnemyController>().Invincible = true;
        GetComponentInChildren<Animator>().enabled = true;
        Smog.SetActive(true);
    }
}