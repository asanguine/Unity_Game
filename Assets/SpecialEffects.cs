using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffects : MonoBehaviour
{
    public static SpecialEffects specialEffects { get; private set; }
    private GameObject smokeVFX;
    private void Awake()
    {
        if (specialEffects != null && specialEffects != this)
        {
            Destroy(this);
        }
        else
        {
            specialEffects = this;
        }
    }
    private void Start()
    {
        smokeVFX = Resources.Load<GameObject>("SmokeVFX");
    }
    public void CreateSmoke(Transform _transform)
    {
        GameObject smoke = Instantiate(smokeVFX, _transform.position-new Vector3(0,0,1),
        Quaternion.identity);
        Destroy(smoke.gameObject,
        smoke.GetComponent<ParticleSystem>().main.duration);
    }
}
