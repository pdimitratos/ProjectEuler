using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ConceptualMath.Testing
{
    public static class ArrayForEach
    {
        public static int[] GetArrayToTest()
            => new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public static void ArrayBuiltInForEach()
        {
            var toTest = GetArrayToTest();
            var listAccum = new List<int>();
            Array.ForEach(toTest, x => x = 2 * x);
        }

        public static void ArrayForEachStatement()
        {
            var toTest = GetArrayToTest();
            var listAccum = new List<int>();
            foreach (int x in toTest)
            {
                //x = 2 * x;
            }
        }

        public static void ArrayForStatement()
        {
            var toTest = GetArrayToTest();
            var listAccum = new List<int>();
            for (int x = 0; x < toTest.Length; x++)
            {
                x = 2 * x;
            }
        }

        public static void ReferenceAllTests()
        {
            ArrayBuiltInForEach();
            ArrayForEachStatement();
            ArrayForStatement();
        }
    }
    public abstract class EntityBase<T>
    {
        public abstract Expression<Func<T, string>> PropertySearchDelegate(string propertyName);
    }
    public class EfModelA : EntityBase<EfModelA>
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public string Prop3 { get; set; }

        public override Expression<Func<EfModelA, string>> PropertySearchDelegate(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Prop1):
                    return (model) => model.Prop1;
                case nameof(Prop2):
                    return (model) => model.Prop2;
                case nameof(Prop3):
                    return (model) => model.Prop3;
                default:
                    throw new Exception("you can't search that");
            }
        }
    }
}
