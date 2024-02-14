using TMPro;
using UnityEngine;

public class TraderLeaderboard : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _money;
    [SerializeField] private TMP_Text _top;

    public void Init(string name, int money, int top)
    {
        _name.text = name;
        _money.text = money.ToString();
        _top.text = top.ToString();
    }
}
