using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_03_25
{
    internal class Money
    {
        private int grivna;
        private int kopeyka;

        public Money(int hryvnias, int kopecks)
        {
            if (hryvnias < 0 || kopecks < 0)
                throw new BankruptException("Отрицатильное кол-во не разрешено.");

            this.grivna = hryvnias + kopecks / 100;
            this.kopeyka = kopecks % 100;
        }

        public static Money operator +(Money a, Money b)
        {
            return new Money(a.grivna + b.grivna, a.kopeyka + b.kopeyka);
        }

        public static Money operator -(Money a, Money b)
        {
            int totalKopeyka1 = a.grivna * 100 + a.kopeyka;
            int totalKopeyka2 = b.grivna * 100 + b.kopeyka;

            if (totalKopeyka1 < totalKopeyka2)
                throw new BankruptException("Выходное значение отрицательное.");

            return new Money(0, totalKopeyka1 - totalKopeyka2);
        }

        public static Money operator /(Money m, int divisor)
        {
            if (divisor == 0)
                throw new DivideByZeroException("Невозможно делить на ноль.");

            int totalKopeyka = m.grivna * 100 + m.kopeyka;
            return new Money(0, totalKopeyka / divisor);
        }

        public static Money operator *(Money m, int multiplier)
        {
            int totalKopeyka = m.grivna * 100 + m.kopeyka;
            return new Money(0, totalKopeyka * multiplier);
        }

        public static Money operator ++(Money m)
        {
            return new Money(m.grivna, m.kopeyka + 1);
        }

        public static Money operator --(Money m)
        {
            if (m.grivna == 0 && m.kopeyka == 0)
                throw new BankruptException("Невозможно уменьшить значение меньше чем до нуля.");

            return new Money(m.grivna, m.kopeyka - 1);
        }

        public static bool operator <(Money a, Money b)
        {
            return (a.grivna * 100 + a.kopeyka) < (b.grivna * 100 + b.kopeyka);
        }

        public static bool operator >(Money a, Money b)
        {
            return (a.grivna * 100 + a.kopeyka) > (b.grivna * 100 + b.kopeyka);
        }

        public static bool operator ==(Money a, Money b)
        {
            return (a.grivna == b.grivna && a.kopeyka == b.kopeyka);
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Money other = (Money)obj;
            return this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(grivna, kopeyka);
        }

        public override string ToString()
        {
            return $"{grivna} Гривен {kopeyka} Копеечек";
        }
    }

}
