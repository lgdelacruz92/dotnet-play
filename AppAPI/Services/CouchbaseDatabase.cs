using Couchbase;
using Couchbase.Extensions.DependencyInjection;

namespace AppAPI.Services
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