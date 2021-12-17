using Newtonsoft.Json;

namespace TrendyolCase.Core.Entities
{
    /// <summary>
    /// This can easily be modified to be BaseEntity<T> and public T Id to support different key types.
    /// Using non-generic integer types for simplicity and to ease caching logic
    /// </summary>
    public abstract class BaseEntity
    {
        public virtual long Id { get; protected set; }
        public string SerializeObject()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
