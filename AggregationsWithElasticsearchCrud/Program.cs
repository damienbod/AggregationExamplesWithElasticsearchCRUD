using System;
using AggregationsWithElasticsearchCrud.Model;
using ElasticsearchCRUD.ContextSearch.SearchModel.AggModel;

namespace AggregationsWithElasticsearchCrud
{
	class Program
	{
		static void Main(string[] args)
		{
			var elasticsearchProvider = new ElasticsearchProvider();
			var resultTopFirstNames = elasticsearchProvider.SearchFirstNameTermsBucketAggregation();
			var resultTopLastNames = elasticsearchProvider.SearchLastNameTermsBucketAggregations();

			// Lets find all the persons with the same name. 
			var resultTopLastNamesGroupByTopFirstName = elasticsearchProvider.SearchLastNameTermsBucketAggregationSignificantTermsBucketAggregationFirstNameMatches();

			// Lets display the results in the console
			foreach (var bucket in resultTopLastNamesGroupByTopFirstName.Buckets)
			{
				var significantTermsBucketAggregationsResult = bucket.GetSubAggregationsFromJTokenName<SignificantTermsBucketAggregationsResult>("testFirstName");

				foreach (var childbucket in significantTermsBucketAggregationsResult.Buckets)
				{
					bool writeHeader = true;
					var hits = childbucket.GetSubAggregationsFromJTokenName<TopHitsMetricAggregationsResult<Person>>("tophits");
					foreach (var hit in hits.Hits.HitsResult)
					{
						if (writeHeader)
						{
							Console.Write("\n{0} {1}, Found Ids: ", hit.Source.FirstName, hit.Source.LastName);
						}
						Console.Write("{0} ", hit.Id);
						writeHeader = false;
					}
				}
			}

			Console.ReadLine();
		}
	}
}
