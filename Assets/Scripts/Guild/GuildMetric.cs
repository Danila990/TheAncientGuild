using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GuildMetric : MonoBehaviour
{
    [SerializeField] private Guild _guild;
    [SerializeField] private TMP_Text _guildTypes;

    private void OnEnable() => _guild.OnChangeTraders += UpdateMetric;

    private void OnDisable() => _guild.OnChangeTraders -= UpdateMetric;


    private void UpdateMetric(List<Trader> traders)
    {
        _guildTypes.text = "";

        var sortTraders = traders.GroupBy(t => t.name)
                        .Select(g => new { Name = g.Key, Count = g.Count() })
                        .ToList();

        foreach (var trader in sortTraders)
            _guildTypes.text = $"{_guildTypes.text} {trader.Name} - {trader.Count} \n";
    }
}
