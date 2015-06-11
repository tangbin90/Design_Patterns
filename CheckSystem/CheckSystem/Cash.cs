using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSystem
{
    abstract class CashBase
    {
        public abstract double acceptCash(double money);
    }

    class CashNormal : CashBase
    {
        public override double acceptCash(double money)
        {
 	        return money;
        }
    }

    class CashCount :CashBase
    {
        private double _discount=1;
        public double discount
        {
            get { return _discount; }
            set{
                if(value<=1&&value>0)
                {
                    _discount=value;
                }
               }
         }
        public CashCount(string count)
        {
            discount=double.Parse(count);
        }
        public override double acceptCash(double money)
        {
            return money * discount;
         }
    }

    class CashReturn : CashBase
    {
        private double moneyCondition = 0.0d;
        private double moneyReturn = 0.0d;
        public CashReturn(string moneyCondition, string moneyReturn)
        {
            this.moneyCondition = double.Parse(moneyCondition);
            this.moneyReturn = double.Parse(moneyReturn);
        }

        public override double acceptCash(double money)
        {
            double result = money;
            if(money >=moneyCondition)
            { 
                result = money - Math.Floor(money / moneyCondition) * moneyReturn;
            }
            return result;
        }
    }

    class CashContex
    {
        private CashBase cashcal;
        public CashContex(string type)
        {
            switch(type)
            {
                case "正常收费":
                    cashcal = new CashNormal();
                    break;
                case "满300反100":
                    cashcal = new CashReturn("300", "100");
                    break;
                case "打八折":
                    cashcal = new CashCount("0.8");
                    break;
            }
        }

        public double CashResult(double money)
        {
            return cashcal.acceptCash(money);
        }

    }
}
