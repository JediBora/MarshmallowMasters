using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class HealthActivationEvent : UnityEvent { }

/// <summary>
/// A health script that contains the ability to have shields, regenerating shields, and regenerating health.
/// </summary>
public class Health : MonoBehaviour
{
    #region Generic Health Values
    public float m_maxHealth;
    [SerializeField] private float m_currentHealth;
    [HideInInspector]
    public bool m_isDead;
    public HealthActivationEvent m_onDied = new HealthActivationEvent();
    #endregion

    #region Shield Values
    [Header("Shields")]
    public bool m_useShields = false;
    public float m_shieldDamageMultiplier = .75f;
    public float m_maxShieldStrength;
    private float m_currentShieldStrength;

    public bool m_shieldRegeneration = true;
    public float m_shieldRegenDelay;
    public float m_shieldRegenTimeToFull;
    private float m_shieldRegenCurrentTime;
    private Coroutine m_shieldRegenerationCoroutine;
    private WaitForSeconds m_shieldRegenDelayTimer;
    #endregion

    #region Health Regeneration Values
    [Header("Health Regeneration")]
    public bool m_useHealthRegeneration = false;
    public float m_maxHealthRegenerationAmount;
    public float m_healthRegnerationDelay;
    public float m_healthRegenTimeToFull;
    private float m_healthRegenCurrentTime;
    private Coroutine m_healthRegenCorotine;
    private WaitForSeconds m_healthRegenDelayTimer;
    #endregion

    private void Start()
    {
        m_shieldRegenDelayTimer = new WaitForSeconds(m_shieldRegenDelay);
        m_healthRegenDelayTimer = new WaitForSeconds(m_healthRegnerationDelay);
        Respawn();
    }
    
    /// <summary>
    /// Needs to be called in order to properly respawn the entity with full health and shields.
    /// </summary>
    public void Respawn()
    {
        StopAllCoroutines();
        m_currentHealth = m_maxHealth;
        m_isDead = false;
        if (m_useShields) m_currentShieldStrength = m_maxShieldStrength;
    }

    /// <summary>
    /// Called to apply damage to this entity. If it uses shields or regenerating health, it takes those into account.
    /// </summary>
    /// <param name="m_takenDamage"></param>
    public void TakeDamage(float m_takenDamage)
    {
        if (!m_isDead)
        {
            StopAllCoroutines();

            if (m_useShields && m_currentShieldStrength > 0)
            {
                m_currentShieldStrength -= m_takenDamage * m_shieldDamageMultiplier;
                if (m_currentShieldStrength < 0)
                {
                    m_currentHealth -= (Mathf.Abs(m_currentShieldStrength * ((1f - m_shieldDamageMultiplier) + 1f)));
                    if (m_currentHealth <= 0)
                    {
                        m_isDead = true;
                        m_onDied.Invoke();
                    }
                    m_currentShieldStrength = 0;
                }
                if (!m_isDead)
                {
                    m_shieldRegenerationCoroutine = StartCoroutine(RegenShield());
                }
            }

            else
            {
                m_currentHealth -= m_takenDamage;
                if (m_currentHealth > 0)
                {
                    if (m_useShields)
                    {
                        m_shieldRegenerationCoroutine = StartCoroutine(RegenShield());
                    }
                    else if (m_useHealthRegeneration && m_currentHealth < m_maxHealthRegenerationAmount)
                    {
                        m_healthRegenCorotine = StartCoroutine(RegenHealth());
                    }
                }
                else
                {
                    m_isDead = true;
                    m_onDied.Invoke();
                }
            }

        }

    }

    /// <summary>
    /// The timer to regnerate the shields
    /// </summary>
    /// <returns></returns>
    IEnumerator RegenShield()
    {
        yield return m_shieldRegenDelayTimer;
        float regenRate = ((m_maxShieldStrength / m_shieldRegenTimeToFull)) / 60f;
        print(regenRate);

        while (m_currentShieldStrength < m_maxShieldStrength)
        {
            m_currentShieldStrength += regenRate;
            yield return null;
        }

        m_currentShieldStrength = m_maxShieldStrength;
        if (m_useHealthRegeneration && m_currentHealth < m_maxHealthRegenerationAmount)
        {
            m_healthRegenCorotine = StartCoroutine(RegenHealth());
        }
        m_shieldRegenerationCoroutine = null;
    }

    /// <summary>
    /// The timer to regenerate the health.
    /// </summary>
    /// <returns></returns>
    IEnumerator RegenHealth()
    {
        yield return m_healthRegenDelayTimer;

        float regenRate = ((m_maxHealth / m_healthRegenTimeToFull) / 60f);

        while (m_currentHealth < m_maxHealthRegenerationAmount)
        {
            m_currentHealth += regenRate;
            yield return null;
        }
        m_currentHealth = m_maxHealthRegenerationAmount;
        m_healthRegenCorotine = null;

    }
}
