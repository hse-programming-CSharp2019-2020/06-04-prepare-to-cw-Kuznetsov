using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CWLibrary
{
    [Serializable]
    public class Dictionary: IEnumerable
    {
        public int locate;

        List<Pair<string, string>> words;

        static Random rnd = new Random();

        public Dictionary()
        {
            locate = rnd.Next(2);
            words = new List<Pair<string, string>>();
        }

        public Dictionary(List<Pair<string, string>> words)
        {
            this.words = words;
            locate = rnd.Next(2);
        }

        public void Add(Pair<string, string> pair)
        {
            words.Add(pair);
        }

        public void Add(string item1, string item2)
        {
            words.Add(new Pair<string, string>(item1, item2));
        }

        public IEnumerator GetEnumerator()
        {
            IEnumerable enumerator;
            if (locate == 0)
                enumerator = (from word in words
                          orderby word.item1
                          select word).ToArray();
            else
                enumerator = (from word in words
                             orderby word.item2
                             select word).ToArray();
            return enumerator.GetEnumerator();
        }

        public IEnumerator MyEnumerator(char ch)
        {
            Pair<string,string>[] enumerator;
            if (locate == 0)
            {
                if (((ch < 'а') || (ch > 'я')) && ((ch < 'А') || (ch > 'Я')))
                    throw new ArgumentException();
                enumerator = (from word in words
                             where word.item1[0] == ch
                             orderby word.item1
                             select word).ToArray();
            }
            else
            {
                if (((ch < 'a') || (ch > 'z')) && ((ch < 'A') || (ch > 'Z')))
                    throw new ArgumentException();
                enumerator = (from word in words
                              where word.item2[0] == ch
                              select word).ToArray();
                Array.Sort(enumerator, (Pair<string, string> x, Pair<string, string> y) => x.item2.CompareTo(y.item2));
            }
            return enumerator.GetEnumerator();
        }

        public void MySerialize(string path)
        {
            using (var fs = new FileStream(path,FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, this);
            }
        }

        static public Dictionary MyDeserialize(string path)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                return (Dictionary)binaryFormatter.Deserialize(fs);
            }
        }
    }
}
