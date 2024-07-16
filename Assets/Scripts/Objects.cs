using System.Collections;
using UnityEngine;

public class Objects : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Transform _parent;
    [SerializeField] private Vector2 _timeCreate;
    [SerializeField] private Vector2 _timeDestroy;

    public Hole[] Holes;

    [SerializeField] private LevelStart _levelStartClass;

    public bool IsCreate = true;

    public IEnumerator ObjectsCreation()
    {
        IsCreate = true;
        while (IsCreate)
        {
            PlacesCheck();
            yield return new WaitForSeconds(Random.Range(_timeCreate.x, _timeCreate.y));
        }
    }    

    public void CreateObjects(Hole hole)
    {
        int indexPrefab = (Random.Range(0, _prefabs.Length));
        GameObject obj = Instantiate(_prefabs[indexPrefab], _parent);
        obj.transform.position = hole.transform.position;
        hole.IsFree = false;
        StartCoroutine(DestroyObjects(obj, hole));
    }
    public IEnumerator DestroyObjects(GameObject o, Hole hole)
    {
        yield return new WaitForSeconds(Random.Range(_timeDestroy.x, _timeDestroy.y));
        Destroy(o);
        hole.IsFree = true;

    }

    private void PlacesCheck()
    {
        Hole[] freeHoles;
        int k = 0;

        for (int i = 0; i < Holes.Length; i++)
        {
            if (Holes[i].IsFree)
            {
                k++;
            }
        }

        freeHoles = new Hole[k];
        int freeIndex = 0;

        for (int i = 0; i < Holes.Length; i++)
        {
            if (Holes[i].IsFree)
            {
                freeHoles[freeIndex] = Holes[i];
                freeIndex++;
            }
        }
        if (freeHoles.Length > 0)
        {
            CreateObjects(freeHoles[Random.Range(0, freeHoles.Length)]);
        }    
    }
}
