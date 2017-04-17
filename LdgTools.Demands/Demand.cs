using System;

namespace LdgTools.Demands
{
    public static class Demand
    {
        public static IDemander<T> That<T>(T value, string name, string valueClass)
        {
            var demander = GetDemanderOfType<T>();
            demander.CheckValue = value;
            demander.ValueName = name;
            demander.ContainingClass = valueClass;
            return demander;
        }

        public static IDemander<T> That<T>(T value, string name)
        {
            var demander = GetDemanderOfType<T>();
            demander.CheckValue = value;
            demander.ValueName = name;
            return demander;
        }

        public static IDemander<T> That<T>(T value)
        {
            var demander = GetDemanderOfType<T>();
            demander.CheckValue = value;
            return demander;
        }

        static string _demanderType;

        private static IDemander<T> GetDemanderOfType<T>()
        {
            var t = Type.GetType(_demanderType);
            t = t.GetGenericTypeDefinition();
            Type[] typeArgs = { typeof(T) };
            t = t.MakeGenericType(typeArgs);
            var obj = Activator.CreateInstance(t);
            var result = obj as IDemander<T>;
            return result;
        }

        public static void InitializeDemand(string dType)
        {
            _demanderType = dType;
        }
    }
}
