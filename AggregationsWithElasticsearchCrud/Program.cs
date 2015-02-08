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

			Console.ReadLine();
		}
	}
}
