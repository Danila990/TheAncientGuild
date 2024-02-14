using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GuildLeaderboard : MonoBehaviour
{
    [SerializeField] private Guild _guild;
    [SerializeField] private TraderLeaderboard _traderLeaderboard;
    [SerializeField] private Transform _spawnParent;

    private List<TraderLeaderboard> _traders = new List<TraderLeaderboard>();

    private void OnEnable() => _guild.OnChangeTraders += UpdateLeaderboard;

    private void OnDisable() => _guild.OnChangeTraders -= UpdateLeaderboard;

    private void UpdateLeaderboard(List<Trader> traders)
    {
        CheckCountTraders(traders.Count);

        SetupLeaderboard(traders);
    }

    private void SetupLeaderboard(List<Trader> traders)
    {
        List<Trader> sortTraders = traders.OrderByDescending(x => x._money).ToList();

        for (int i = 0; i < sortTraders.Count; i++)
            _traders[i].Init(sortTraders[i].name, sortTraders[i]._money, i + 1);
    }

    private void CheckCountTraders(int tradersCount)
    {
        if (tradersCount > _traders.Count)
            for (int i = _traders.Count; i < tradersCount; i++)
                _traders.Add(Instantiate(_traderLeaderboard, _spawnParent));
    }
}
