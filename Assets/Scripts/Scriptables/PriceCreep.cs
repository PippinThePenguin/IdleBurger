using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerNamespace {
  
  [CreateAssetMenu(fileName = "new_Creep", menuName = "Creep")]
  public class PriceCreep : ScriptableObject {
    public new string name;
    public List<int> SpeedPriceCreep;
    public List<int> ClickPriceCreep;
    public List<int> MoneyPriceCreep;

    private int _speedNode = 0;
    private int _clickNode = 0;
    private int _moneyNode = 0;
    
    public void ClearNodes() {
      _speedNode = 0;
      _clickNode = 0;
      _moneyNode = 0;
    }

    public int ReturnNextSpeedPrice() {
      
      if (_speedNode == SpeedPriceCreep.Count - 1) {
        return SpeedPriceCreep[_speedNode];
      }
      var nextPrice = SpeedPriceCreep[_speedNode];
      _speedNode++;
      return nextPrice;
    }

    public int ReturnNextClickPrice() {

      if (_clickNode == ClickPriceCreep.Count - 1) {
        return ClickPriceCreep[_clickNode];
      }
      var nextPrice = ClickPriceCreep[_clickNode];
      _clickNode++;
      return nextPrice;
    }

    public int ReturnNextMoneyPrice() {

      if (_moneyNode == MoneyPriceCreep.Count - 1) {
        return MoneyPriceCreep[_moneyNode];
      }
      var nextPrice = MoneyPriceCreep[_moneyNode];
      _moneyNode++;
      return nextPrice;
    }
  }
}
  
