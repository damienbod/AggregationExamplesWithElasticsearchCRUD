using System;

namespace AggregationsWithElasticsearchCrud
{
	class Program
	{
		static void Main(string[] args)
		{
			var elasticsearchProvider = new ElasticsearchProvider();
			elasticsearchProvider.SearchFirstNameTermsBucketAggregation();
			elasticsearchProvider.SearchLastNameTermsBucketAggregations();

			// Lets find all the persons with the same name. 
			elasticsearchProvider.SearchLastNameTermsBucketAggregationSignificantTermsBucketAggregationFirstNameMatches();

			// Get the ExtendedStats on the "modifieddate" field for the whole index and per bucket from a DateRange Aggregation
			elasticsearchProvider.SearchAggDateRangesBucketAggregationWithExtentedStats();
			Console.ReadLine();
		}
	}
}
