using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWLibrary
{
    [Serializable]
    public class Pair<T, U> : IComparable 
        where T : IComparable
        where U : IComparable
    {
        public T item1;
        public U item2;

        public Pair(T item1, U item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public int CompareTo(Pair<T, U> pair) => item1.CompareTo(pair.item1);

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => item1.ToString() + ' ' + item2.ToString();

    }
}
