using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookParticlePoolerController : MonoBehaviour {

    public static HookParticlePoolerController ins;
    [SerializeField]
    GameObject particlePrefab;
    [SerializeField]
    ObjectPooler pooler;
    public ObjectPooler ObjectPooler
    {
        get { return pooler; }
    }

    void Start () {
        ins = this;
        pooler.Preload(particlePrefab, 5);
    }

	public void Spawn(Vector3 pos)
    {
        GameObject _obj = pooler.GetGameObject(false);
        if(_obj != null)
        {
            _obj.transform.position = pos;
            _obj.SetActive(true);
        }
        else
        {
            pooler.PoolGameObject(_obj = Instantiate(particlePrefab, pos, Quaternion.Euler(Vector3.zero)));
        }
    }

}
