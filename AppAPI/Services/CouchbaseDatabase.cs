using Couchbase;
using Couchbase.Extensions.DependencyInjection;

namespace AppServices
{
    public class CouchbaseDatabase
    {
        private readonly INamedBucketProvider _bucketProvider;

        public CouchbaseDatabase(INamedBucketProvider bucketProvider)
        {
            _bucketProvider = bucketProvider;
        }
    }
}