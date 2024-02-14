

public class ScammerTrader : Trader
{
    private int _numberTrader = 0;
    private bool _isFirstTrade = true;

    public override void UpdateNextTradingStrategies(TypeTradingStrategies opponentTradingStrategies)
    {
        _numberTrader++;
        if (_isFirstTrade) 
        {
            _tradingStrategies = opponentTradingStrategies;
            _isFirstTrade = false;
            return;
        }
        else if(_numberTrader >= 5)
            _tradingStrategies = TypeTradingStrategies.Cheat;
    }
}
