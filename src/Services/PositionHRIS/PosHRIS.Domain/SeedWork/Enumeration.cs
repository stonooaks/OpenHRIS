using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace empHRIS.Domain.SeedWork
{
    public abstract class Enumeration : IComparable
    {

        public string Name { get; private set; }
        public int Id { get; private set; }

        /// <summary>
        /// Enumeration Constructor
        /// </summary>
        protected Enumeration() { }

        /// <summary>
        /// Enumeration Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach(var info in fields)
            {
                var instance = new T();
                var locatedValue = info.GetValue(instance) as T;

                if (locatedValue != null)
                {
                    yield return locatedValue;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstValue"></param>
        /// <param name="secondValue"></param>
        /// <returns></returns>
        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            return Math.Abs(firstValue.Id - secondValue.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T FromValue<T>(int value) where T : Enumeration, new()
        {
            return Parse<T, int>(value, "value", item => item.Id == value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static T FromDisplayName<T>(string displayName) where T : Enumeration, new()
        {
            return Parse<T, string>(displayName, "display name", item => item.Name == displayName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="value"></param>
        /// <param name="description"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if(matchingItem == null)
            {
                var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                throw new InvalidOperationException(message);
            }
            return matchingItem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            return Id.CompareTo(((Enumeration)obj).Id);
        }
    }
}
