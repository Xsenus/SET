using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SET.Model
{
    public class EasySet<T> : IEnumerable
    {
        private List<T> items = new List<T>();
        public int Count => items.Count;

        public EasySet() { }

        public EasySet(T item)
        {
            items.Add(item);
        }

        public EasySet(IEnumerable<T> items)
        {
            this.items = items.ToList();
        }

        public void Add(T item)
        {
            //if (items.Contains(item))
            //{
            //    return;
            //}

            foreach (var i in items)
            {
                if (i.Equals(item))
                {
                    return;
                }
            }

            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public EasySet<T> Union(EasySet<T> easySet)
        {
            //return new EasySet<T>(items.Union(easySet.items));

            EasySet<T> result = new EasySet<T>();

            foreach (var item in items)
            {
                result.Add(item);
            }

            foreach (var item in easySet.items)
            {
                result.Add(item);
            }

            return result;
        }

        public EasySet<T> Intersection(EasySet<T> easySet)
        {
            //return new EasySet<T>(items.Intersect(easySet.items));

            var result = new EasySet<T>();
            EasySet<T> big;
            EasySet<T> small;

            if (Count >= easySet.Count)
            {
                big = this;
                small = easySet;
            }
            else
            {
                big = easySet;
                small = this;
            }

            foreach (var item1 in small.items)
            {
                foreach (var item2 in big.items)
                {
                    if (item1.Equals(item2))
                    {
                        result.Add(item1);
                        break;
                    }
                }
            }

            return result;
        }

        public EasySet<T> Difference(EasySet<T> easySet)
        {
            //return new EasySet<T>(items.Except(easySet.items));

            var result = new EasySet<T>(items);

            foreach (var item in easySet.items)
            {
                result.Remove(item);
            }

            return result;
        }

        public bool Subset(EasySet<T> easySet)
        {
            //return items.All(i => easySet.items.Contains(i));

            foreach (var item1 in items)
            {
                var equals = false;

                foreach (var item2 in easySet.items)
                {
                    if (item1.Equals(item2))
                    {
                        equals = true;
                        break;
                    }
                }

                if (!equals)
                {
                    return false;
                }
            }

            return true;
        }

        public EasySet<T> SymmetricDifference(EasySet<T> easySet)
        {
            //return new EasySet<T>(items.Except(easySet.items).Union(easySet.items.Except(items)));

            var result = new EasySet<T>();

            foreach (var item1 in items)
            {
                var equals = false;

                foreach (var item2 in easySet.items)
                {
                    if (item1.Equals(item2))
                    {
                        equals = true;
                        break;
                    }
                }

                if (!equals)
                {
                    result.Add(item1);
                }
            }

            foreach (var item1 in easySet.items)
            {
                var equals = false;

                foreach (var item2 in items)
                {
                    if (item1.Equals(item2))
                    {
                        equals = true;
                        break;
                    }
                }

                if (!equals)
                {
                    result.Add(item1);
                }
            }

            return result;
        }

        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
