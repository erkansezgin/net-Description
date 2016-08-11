namespace DescriptionLibrary
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Get the DescriptionAttribute text from classes, enum values, properties and others.
    /// </summary>
    public static class DescriptionGetter
    {
        /// <summary>
        /// Get the DescriptionAttribute text from a constructor.
        /// </summary>
        /// <param name="type">Type to get the description from</param>
        /// <param name="types">Types of the desired constructor to get the description from</param>
        /// <returns>The DescriptionAttribute text from the given constructor or null if none was found</returns>
        public static string ConstructorDescription(this Type type, params Type[] types)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            var constructor = type.GetConstructor(types);
            return constructor == null ? null : GetDescription(constructor);
        }

        /// <summary>
        /// Get the DescriptionAttribute text from an enum value.
        /// </summary>
        /// <param name="value">Enum value to get the description from</param>
        /// <returns>The DescriptionAttribute text from the given enum value or null if none was found</returns>
        public static string Description(this Enum value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            return value.GetType().FieldDescription(value.ToString());
        }

        /// <summary>
        /// Get the DescriptionAttribute text from a type.
        /// </summary>
        /// <param name="type">Type to get the description from</param>
        /// <returns>The DescriptionAttribute text from the given type or null if none was found</returns>
        public static string Description(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            return GetDescription(type);
        }

        /// <summary>
        /// Get the DescriptionAttribute text from the given event property.
        /// </summary>
        /// <param name="type">Type of the event property to get the description from</param>
        /// <param name="eventName">Name of the event property to get the description from</param>
        /// <returns>The DescriptionAttribute text from the given event property or null if none was found</returns>
        public static string EventDescription(this Type type, string eventName)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (eventName == null)
                throw new ArgumentNullException("eventName");

            var @event = type.GetEvent(eventName);
            return @event == null ? null : GetDescription(@event);
        }

        /// <summary>
        /// Get the DescriptionAttribute text from the given field.
        /// </summary>
        /// <param name="type">Type of the field to get the description from</param>
        /// <param name="fieldName">Name of the field to get the description from</param>
        /// <returns>The DescriptionAttribute text from the given field property or null if none was found</returns>
        public static string FieldDescription(this Type type, string fieldName)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (fieldName == null)
                throw new ArgumentNullException("fieldName");

            var field = type.GetField(fieldName);
            return field == null ? null : GetDescription(field);
        }

        /// <summary>
        /// Get the DescriptionAttribute text from the given method.
        /// </summary>
        /// <param name="type">Type of the method to get the description from</param>
        /// <param name="methodName">Name of the method to get the description from</param>
        /// <returns>The DescriptionAttribute text from the given method property or null if none was found</returns>
        public static string MethodDescription(this Type type, string methodName)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (methodName == null)
                throw new ArgumentNullException("methodName");

            var method = type.GetMethod(methodName);
            return method == null ? null : GetDescription(method);
        }

        /// <summary>
        /// Get the DescriptionAttribute text from the given method parameter.
        /// </summary>
        /// <param name="type">Type of the method to get the parameter description from</param>
        /// <param name="methodName">Name of the method to get the parameter description from</param>
        /// <param name="parameterName">Name of the parameter of the method to get the description from</param>
        /// <returns>The DescriptionAttribute text from the given method parameter or null is none was found</returns>
        public static string ParameterDescription(this Type type, string methodName, string parameterName)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (methodName == null)
                throw new ArgumentNullException("methodName");

            if (parameterName == null)
                throw new ArgumentNullException("parameterName");

            var method = type.GetMethod(methodName);

            if (method == null)
                return null;

            var parameter = method.GetParameters().FirstOrDefault(p => p.Name == parameterName);
            return parameter == null ? null : GetDescription(parameter);
        }

        /// <summary>
        /// Get the DescriptionAttribute text from the given property.
        /// </summary>
        /// <param name="type">Type of the property to get the description from</param>
        /// <param name="propertyName">Name of the property to get the description from</param>
        /// <returns>The DescriptionAttribute text from the given type or null if none was found</returns>
        public static string PropertyDescription(this Type type, string propertyName)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (propertyName == null)
                throw new ArgumentNullException("propertyName");

            var property = type.GetProperty(propertyName);
            return property == null ? null : GetDescription(property);
        }

        /// <summary>
        /// Get the DescriptionAttribute text from the given method return.
        /// </summary>
        /// <param name="type">Type of the method to get the return description from</param>
        /// <param name="methodName">Name of the method to get the return description from</param>
        /// <returns>The DescriptionAttribute text from the given method return or null if none was found</returns>
        public static string ReturnDescription(this Type type, string methodName)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (methodName == null)
                throw new ArgumentNullException("methodName");

            var method = type.GetMethod(methodName);

            if (method == null)
                return null;

            return method.ReturnParameter == null ? null : GetDescription(method.ReturnParameter);
        }

        private static string GetDescription(ICustomAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetCustomAttributes(true).OfType<DescriptionAttribute>().FirstOrDefault();

            if (attribute == null)
                return null;

            return attribute.Description;
        }
    }
}
