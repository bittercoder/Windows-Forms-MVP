using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DevDefined.Winforms.Framework
{
    public static class Reflector
    {
        public static TAttribute GetAttribute<TAttribute>(ICustomAttributeProvider provider)
            where TAttribute : Attribute
        {
            object[] attributes = provider.GetCustomAttributes(typeof (TAttribute), false);

            if ((attributes == null) || (attributes.Length == 0)) return null;

            return attributes[0] as TAttribute;
        }

        public static TAttribute GetAttribute<TAttribute>(object target)
            where TAttribute : Attribute
        {
            return GetAttribute<TAttribute>(target.GetType());
        }

        public static IList<TAttribute> GetAttributes<TAttribute>(object target)
            where TAttribute : Attribute
        {
            return GetAttributes<TAttribute>(target.GetType());
        }

        public static IList<TAttribute> GetAttributes<TAttribute>(ICustomAttributeProvider provider)
            where TAttribute : Attribute
        {
            object[] untypedAttributes = provider.GetCustomAttributes(typeof (TAttribute), false);

            if (untypedAttributes == null) return new List<TAttribute>();

            return untypedAttributes.Cast<TAttribute>().ToList();
        }

        public static TInstance Construct<TInstance>(Type type)
        {
            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
            return (TInstance) constructor.Invoke(null);
        }
    }
}