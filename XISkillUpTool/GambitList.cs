using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XISkillUpTool
{
    public class GambitList : IList<Gambit>
    {
        private List<Gambit> gambitList;
        
        public GambitList()
        {
            gambitList = new List<Gambit>();
        }

        public GambitList Evaluate(FFACEState _ffstate)
        {
            var TriggeredGambits = new GambitList();
            foreach(Gambit g in gambitList)
            {
                if(g.Evaluate(_ffstate)) TriggeredGambits.Add(g);
            }
            return TriggeredGambits;
        }

        #region IList<Gambit>
        public int IndexOf(Gambit item)
        {
            return gambitList.IndexOf(item);
        }

        public void Insert(int index, Gambit item)
        {
            gambitList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            gambitList.RemoveAt(index);
        }

        public Gambit this[int index]
        {
            get
            {
                return gambitList[index];
            }
            set
            {
                gambitList[index] = value;
            }
        }

        public void Add(Gambit item)
        {
            gambitList.Add(item);
        }

        public void Clear()
        {
            gambitList.Clear();
        }

        public bool Contains(Gambit item)
        {
            return gambitList.Contains(item);
        }

        public void CopyTo(Gambit[] array, int arrayIndex)
        {
            gambitList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return gambitList.Count; }
        }

        public bool IsReadOnly
        {
            get { return this.IsReadOnly; }
        }

        public bool Remove(Gambit item)
        {
            return gambitList.Remove(item);
        }

        public IEnumerator<Gambit> GetEnumerator()
        {
            return gambitList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return gambitList.GetEnumerator();
        }
        #endregion
    }
}
