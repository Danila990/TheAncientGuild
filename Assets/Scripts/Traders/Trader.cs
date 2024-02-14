using UnityEngine;

public abstract class Trader : MonoBehaviour
{
    private const int CHANGE_ERROR = 5;

    [SerializeField] protected TypeTradingStrategies _tradingStrategies;

    public int _money { get; private set; } = 0;

    public void ChangeCountMoney(int amount)
    {
        _money += amount;
    }

    public void ResetMoney()
    {
        _money = 0;
    }

    public TypeTradingStrategies GetTradingStrategies()
    {
        if (ChangeError(_tradingStrategies, out TypeTradingStrategies errorTradingStrategies))
            return errorTradingStrategies;

        return _tradingStrategies;
    }

    public virtual void UpdateNextTradingStrategies(TypeTradingStrategies opponentTradingStrategies) { }

    public virtual void EndTrading() { }

    private bool ChangeError(TypeTradingStrategies currentTradingStrategies, out TypeTradingStrategies errorTradingStrategies)
    {
        errorTradingStrategies = default;

        if (Random.Range(0, 100) <= CHANGE_ERROR)
        {
            if (currentTradingStrategies.Equals(TypeTradingStrategies.Cheat))
                errorTradingStrategies =  TypeTradingStrategies.Honestly;
            else
                errorTradingStrategies = TypeTradingStrategies.Cheat;

            return true;
        }

        return false;
    }
}
