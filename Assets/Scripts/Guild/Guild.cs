using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MarketGuild))]
public class Guild : MonoBehaviour
{
    [SerializeField] private GuildData _guildData;
    [SerializeField] private MarketGuild _marketGuild;

    private List<Trader> _guildTraders = new List<Trader>();

    public event Action<List<Trader>> OnChangeTraders;

    private void Start()  
    {
        AddStartTraders(_guildData.AmountTraders);
        OnChangeTraders?.Invoke(_guildTraders);
    }

    public void EndYear()
    {
        _marketGuild.TradeAllTraders(_guildTraders);

        OnChangeTraders?.Invoke(_guildTraders);
    }

    public void NewYear()
    {
        int countNewTraders = (int)(_guildTraders.Count * (_guildData.ExclusionPercentage * 0.01));

        ClearTraders(countNewTraders);
        AddNewYearTraders(countNewTraders);
        ResetTraders();

        OnChangeTraders?.Invoke(_guildTraders);
    }

    private void AddNewYearTraders(int amount)
    {
        List<Trader> sortTraders = _guildTraders.OrderByDescending(x => x._money).Take(amount).ToList();

        foreach (Trader trader in sortTraders)
            _guildTraders.Add(CreateTrader(trader));
    }

    private void ClearTraders(int amount)
    {
        List<Trader> sortTraders = _guildTraders.OrderBy(x => x._money).Take(amount).ToList();

        foreach (Trader trader in sortTraders)
        {
            _guildTraders.Remove(trader);
            Destroy(trader.gameObject);
        }
    }

    private void ResetTraders()
    {
        foreach (Trader trader in _guildTraders)
            trader.ResetMoney();

        _guildTraders = _guildTraders.OrderBy(_x => _x.name).ToList();
    }

    private void AddStartTraders(int amount)
    {
        int countTypeTraders = amount / _guildData.CountTypeTraders;

        foreach (Trader trader in _guildData.TypeTraders)
            for (int i = 0; i < countTypeTraders; i++)
                _guildTraders.Add(CreateTrader(trader));

    }

    private Trader CreateTrader(Trader trader)
    {
        Trader returnTrader = Instantiate(trader, transform);
        returnTrader.name = returnTrader.name.Remove(returnTrader.name.Length - 7);
        return returnTrader;
    }
}
