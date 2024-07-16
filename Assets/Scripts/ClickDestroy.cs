using TMPro;
using UnityEngine;

public class ClickDestroy : MonoBehaviour
{

    [SerializeField] private TMP_Text _countsText;
    [SerializeField] private Object _objectClass;

    private int _allcounts;
    public void ClickOnCat(int add)
    {
        _allcounts += add;
        _countsText.text = _allcounts.ToString();
    }

}
