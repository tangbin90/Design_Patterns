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

    class CashFactory
    {
        public static CashBase creatCashAccept(string type)
        {
            CashBase cs = null;
            switch(type)
            {
                case "正常收费":
                    cs=new CashNormal();
                    break;
                case "满300反100":
                    CashReturn crl = new CashReturn("300","100");
                    cs=crl;
                    break;
                case "打八折":
                    CashCount cr2 = new CashCount("0.8");
                    cs = cr2;
                    break;
            }
            return cs;
        }

    }
}
