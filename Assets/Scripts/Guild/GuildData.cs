using UnityEngine;

[CreateAssetMenu(fileName = "new Guild Data", menuName = "Guild Data")]
public class GuildData : ScriptableObject
{
    [Header("Result trade")]
    [SerializeField] private int _twoHonestly = 4;
    [SerializeField] private int _twoCheat = 2;
    [SerializeField] private int _oneHonestly = 1;
    [SerializeField] private int _oneCheat = 5;
    [Header("Traders")]
    [SerializeField] private Trader[] _typeTraders;
    [SerializeField] private int _amountTraders = 60;
    [SerializeField, Range(0, 99)] private int _exclusionPercentage = 20;

    public int TwoHonestly => _twoHonestly;
    public int TwoCheat => _twoCheat;
    public int OneHonestly => _oneHonestly;
    public int OneCheat => _oneCheat;
    public Trader[] TypeTraders => _typeTraders;

    public int CountTypeTraders => _typeTraders.Length;
    public int AmountTraders => _amountTraders;
    public int ExclusionPercentage => _exclusionPercentage;
}
