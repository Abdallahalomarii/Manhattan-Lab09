using Manhattan.Classes;
using Newtonsoft.Json;
using System.Text.Json;

namespace Manhattan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonPath = @"../../../../data.json";

            string jsonString = File.ReadAllText(jsonPath);

            List<Properties> properties = Test1(jsonString);

            // ******** uncomment any method you want to see ********

            //PrintAllNeighborhood(properties);

            //PrintAllNeighborhoodNotNull(properties);

            //NotDuplicateNeighborhoodNames(properties);

            //NotDuplicateNeighborhoodNamesAndWithOutNull(properties);

            LINQStatement(properties);

        }
        /// <summary>
        /// Return a list the properties as a list 
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <returns></returns>
        public static List<Properties> Test1(string jsonPath)
        {
            RootData? root = JsonConvert.DeserializeObject<RootData>(jsonPath);

            List<FeatureClass> features = root.features;

            List<Properties> propertiesList = new List<Properties>();

            foreach (var item in features)
            {
                propertiesList.Add(item.properties);
            }
            return propertiesList;
        }

        /// <summary>
        /// printing the whole neighborhood names including the null
        /// </summary>
        /// <param name="properties"></param>
        public static void PrintAllNeighborhood(List<Properties> properties)
        {
            var filterNeighborhood = properties
                                    .Select(x => x.neighborhood);
            int index = 1;
            foreach (var neighborhood in filterNeighborhood)
            {
                Console.WriteLine(index + " - " + neighborhood);
                index++;
            }
        }

        /// <summary>
        /// printing the neighborhood names that has no null value
        /// </summary>
        /// <param name="properties"></param>
        public static void PrintAllNeighborhoodNotNull(List<Properties> properties)
        {
            var filterNeighborhood = properties
                        .Where(x => !string.IsNullOrEmpty(x.neighborhood))
                        .Select(x => x.neighborhood);

            int index = 1;
            foreach (var neighborhood in filterNeighborhood)
            {
                Console.WriteLine(index + " - " + neighborhood);
                index++;
            }
        }

        /// <summary>
        /// printing the neighborhood names that appears one time at least no duplicate but include the null 
        /// </summary>
        /// <param name="properties"></param>
        public static void NotDuplicateNeighborhoodNames(List<Properties> properties)
        {
            var filterNeighborhood = properties
                        //.Where(x => !string.IsNullOrEmpty (x.neighborhood))
                        .GroupBy(x => x.neighborhood)
                        .Select(group => group.First().neighborhood);

            int index = 1;
            foreach (var neighborhood in filterNeighborhood)
            {
                Console.WriteLine(index + " - " + neighborhood);
                index++;
            }
        }

        /// <summary>
        /// printing the neighborhood names that appears one time at least no duplicate and it is not including the null
        /// </summary>
        /// <param name="properties"></param>
        public static void NotDuplicateNeighborhoodNamesAndWithOutNull(List<Properties> properties)
        {
            var filterNeighborhood = properties
                       .Where(x => !string.IsNullOrEmpty(x.neighborhood))
                       .GroupBy(x => x.neighborhood)
                       .Select(group => group.First().neighborhood);

            int index = 1;
            foreach (var neighborhood in filterNeighborhood)
            {
                Console.WriteLine(index + " - " + neighborhood);
                index++;
            }
        }

        /// <summary>
        /// using linq statement, applying the all question in one query
        /// </summary>
        /// <param name="properties"></param>
        public static void LINQStatement(List<Properties> properties)
        {
            var filterNeighborhood = (from x in properties 
                                     where !string.IsNullOrEmpty(x.neighborhood)
                                     select x.neighborhood)
                                     .Distinct();

             int index = 1;
            foreach (var neighborhood in filterNeighborhood)
            {
                Console.WriteLine(index + " - " + neighborhood);
                index++;
            }
        }
    }
}