using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cat : MonoBehaviour, IPointerDownHandler 
{
    [SerializeField] private Objects _objectsClass;
    [SerializeField] private int _counts;
    private ClickDestroy _clickClass;

    private void Awake()
    {
       _clickClass = FindObjectOfType<ClickDestroy>(); 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _clickClass.ClickOnCat(_counts);
        Destroy(gameObject);

    }
}
