using UnityEngine;

public class HealthBase : MonoBehaviour
{

    public int startLife = 10;
    public bool destroyOnKill = false;
    public float delayToKill = 0f;

    private int _currentLife;
    private bool _isDead = false;

    private void Awake()
    {

    }

    private void Init()
    {
        _currentLife = startLife;
        _isDead = false;
    }

    public void Demage(int demage)
    {
        if (_isDead) 
        { 
            return;         
        }

        if(_currentLife <= 0)
        {
            Kill();
        }
    } 

    private void Kill()
    {
        _isDead = true;
        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
    }

}
