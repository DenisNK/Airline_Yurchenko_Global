﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Airline_Yurchenko.SortExtentions
{
    public static class CustomSort_Expression
    {
        public static IEnumerable<T> OrderByViaExpressions<T>(this IEnumerable<T> source, string propName)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "x");
            Expression propertyExpression = Expression.Property(parameterExpression, propName);
            var resultExpression = Expression.Lambda(propertyExpression, parameterExpression);

            var lambda = resultExpression.Compile();

            Type enumerableType = typeof(Enumerable);
            var methods = enumerableType.GetMethods(BindingFlags.Public | BindingFlags.Static);
            var selectedMethods = methods.Where(m => m.Name == "OrderBy" && m.GetParameters().Count() == 2);
            var method = selectedMethods.First();

            method = method.MakeGenericMethod(typeof(T), propertyExpression.Type);
            var result = (IEnumerable<T>)method.Invoke(null, new object[] { source, lambda });

            return result;
        }
    }
}
