TermsBucketAggregationsResult aggResult;
var search = new Search
{
	Aggs = new List<IAggs>
	{
		new TermsBucketAggregation("testFirstName", "firstname")
		{
			Size = 20
		}
	}
};

using (var context = new ElasticsearchContext(ConnectionString, ElasticsearchMappingResolver))
{
	var items = context.Search<Person>(
		search, 
		new SearchUrlParameters 
		{ 
			SeachType = SeachType.count 
		});
		
	aggResult = 
		items.PayloadResult.Aggregations.GetComplexValue<TermsBucketAggregationsResult>("testFirstName");
}