using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public List<GameObject> lstGameObject;

    public void PoolGameObject(GameObject gameObject)
    {
        lstGameObject.Add(gameObject);
    }

    public GameObject GetGameObject(bool activeInHeirarchy = false)
    {
        for (int i = 0; i < lstGameObject.Count; i++)
        {
            if (!lstGameObject[i].activeInHierarchy && activeInHeirarchy == false)
            {
                return lstGameObject[i];
            }
            else if(lstGameObject[i].activeInHierarchy && activeInHeirarchy == true)
            {
                return lstGameObject[i];
            }
        }

        return null;
    }

    public void Preload(GameObject obj, int count)
    {
        for(int i=0; i<count; i++)
        {
            GameObject _obj =  Instantiate(obj);
            _obj.SetActive(false);
            lstGameObject.Add(_obj);
        }
    }
}
